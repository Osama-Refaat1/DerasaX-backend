using DerasaX.Application.Dto.AccountDto;
using DerasaX.Application.Services.Abstractions.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountServices _accountServices;

        public AccountController(IAccountServices accountServices)
        {
            _accountServices=accountServices;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _accountServices.Login(loginDto);
            if (response.IsAuthenticated==false)
            {
                return BadRequest(response);
            }

            if (!string.IsNullOrEmpty(response.RefreshToken))
                SetRfreshTokenInCookie(response.RefreshToken, response.RefreshTokenExpiration);

            return Ok(response);
        }
        [HttpGet("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var result = await _accountServices.RefreshTokenAsync(refreshToken);
            if (!result.IsAuthenticated)
            {
                return Unauthorized(new { Message = result.Message });
            }
            SetRfreshTokenInCookie(result.RefreshToken, result.RefreshTokenExpiration);
            return Ok(result);
        }
        [HttpPost("RevokeToken")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenDto revokeTokenDto)
        {
            var token = revokeTokenDto.Token??Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(token))
                return BadRequest("Token is required !");
            var result = await _accountServices.RevokeTokenAsync(token);
            if (!result.Success)
                return BadRequest("Token is invalid !");
            return Ok(new { Message = result.Message });
        }
        private void SetRfreshTokenInCookie(string refreshToken, DateTime expires)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly =true,
                Expires = expires.ToLocalTime()
            };
            Response.Cookies.Append("refreshToken", refreshToken, cookieOptions);
        }
    }
}
