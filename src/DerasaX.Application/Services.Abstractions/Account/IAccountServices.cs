using DerasaX.Application.Dto.AccountDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.Account
{
    public interface IAccountServices
    {
        Task<AuthModel> Login(LoginDto loginDto);
        Task<AuthModel> RefreshTokenAsync(string token);
        Task<TokenRevocationResult> RevokeTokenAsync(string token);
    }
}
