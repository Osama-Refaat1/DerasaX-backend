using DerasaX.Application.Dto.AccountDto;
using DerasaX.Application.Dto.SecurityQuestionDto;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.SecurityQuestions
{
    public interface ISecurityQuestionService
    {
        Task<IEnumerable<SecurityQuestion>> GetAllQuestionsAsync();
        Task<bool> SetSecurityQuestionAsync(string userId, SetSecurityQuestionDto dto);
        Task<string?> ForgetPasswordAsync(ForgetPasswordDto dto);
        Task<bool> ResetPasswordAsync(ResetPasswordDto dto);
    }
}
