using DerasaX.Application.Dto.AccountDto;
using DerasaX.Application.Services.Abstractions.Account;
using DerasaX.Domain.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Account
{
    public class AccountServices : IAccountServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountServices(UserManager<ApplicationUser> userManager,IConfiguration configuration)
        {
            _userManager=userManager;
            _configuration=configuration;
        }
        public async Task<AuthModel> Login(LoginDto loginDto)
        {
            var authModel = new AuthModel();
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.LoginCode == loginDto.UserID);
            if (user==null||!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                authModel.Message="UserID or Password is incorrect";
                return authModel;
            }

            var JwtSecurityToken = await CreateJwtToken(user);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(JwtSecurityToken);
            authModel.Message=$"{user.UserName} login successfully";
            authModel.Id=user.Id;
            authModel.UserName = user.FullName;
            authModel.IsAuthenticated=true;
            authModel.Token = tokenString;

            if (user.refreshTokens.Any(t => t.IsActive))
            {
                var activeRefreshToken = user.refreshTokens.FirstOrDefault(t => t.IsActive);
                authModel.RefreshToken=activeRefreshToken.Token;
                authModel.RefreshTokenExpiration=activeRefreshToken.ExpiresOn;
            }
            else
            {
                var refreshToken = GenerateRefreshToken();
                authModel.RefreshToken=refreshToken.Token;
                authModel.RefreshTokenExpiration=refreshToken.ExpiresOn;
                user.refreshTokens.Add(refreshToken);
                await _userManager.UpdateAsync(user);
            }
            return authModel;
        }
        public async Task<AuthModel> RefreshTokenAsync(string token)
        {
            var authModel = new AuthModel();
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.refreshTokens.Any(t => t.Token==token));
            if (user is null)
            {
                authModel.Message="Invalid token";
                return authModel;
            }
            var refreshToken = user.refreshTokens.Single(t => t.Token==token);
            if (!refreshToken.IsActive)
            {
                authModel.Message="Inactive token";
                return authModel;
            }

            refreshToken.RevokedOn=DateTime.UtcNow;

            var newRefreshToken = GenerateRefreshToken();
            user.refreshTokens.Add(newRefreshToken);
            await _userManager.UpdateAsync(user);

            var jwtToken = await CreateJwtToken(user);
            authModel.IsAuthenticated =true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            authModel.UserName = user.UserName;
            var roles = await _userManager.GetRolesAsync(user);
            authModel.RefreshToken = newRefreshToken.Token;
            authModel.RefreshTokenExpiration = newRefreshToken.ExpiresOn;
            return authModel;
        }
        public async Task<TokenRevocationResult> RevokeTokenAsync(string token)
        {
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.refreshTokens.Any(t => t.Token == token));
            if (user == null)
            {
                return new TokenRevocationResult
                {
                    Success = false,
                    Message = "Invalid token."
                };
            }
            var refreshToken = user.refreshTokens.Single(t => t.Token == token);

            if (!refreshToken.IsActive)
                return new TokenRevocationResult
                {
                    Success = false,
                    Message = "Token is already revoked or expired."
                };

            refreshToken.RevokedOn = DateTime.UtcNow;
            await _userManager.UpdateAsync(user);
            return new TokenRevocationResult
            {
                Success = true,
                Message = "Token revoked successfully."
            };
        }
        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var UserClaims = await _userManager.GetClaimsAsync(user);
            var Roles = await _userManager.GetRolesAsync(user);
            var RoleClaims = new List<Claim>();
            foreach (var Rolename in Roles)
            {
                RoleClaims.Add(new Claim(ClaimTypes.Role, Rolename));
            }
            var Claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim("uid",user.Id),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim("tenantId", user.TenantId),

            }.Union(UserClaims)
            .Union(RoleClaims);

            var SecretKeyString = _configuration.GetSection("SecretKey").Value;
            var SecreteKeyBytes = Encoding.UTF8.GetBytes(SecretKeyString);
            SecurityKey securityKey = new SymmetricSecurityKey(SecreteKeyBytes);
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var Expiredate = DateTime.Now.AddDays(2);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                claims: Claims,
                signingCredentials: signingCredentials,
                expires: Expiredate
                );
            return jwtSecurityToken;
        }
        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var generator = new RNGCryptoServiceProvider();
            generator.GetBytes(randomNumber);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomNumber),
                ExpiresOn = DateTime.UtcNow.AddDays(10),
                CreatedOn =DateTime.UtcNow
            };
        }
    }
}
