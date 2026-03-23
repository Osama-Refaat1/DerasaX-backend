using DerasaX.Application.Dto.SecurityQuestionDto;
using DerasaX.Application.Services.Abstractions.SecurityQuestions;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.SecurityQuestions
{
    public class SecurityQuestionService : ISecurityQuestionService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        public SecurityQuestionService(UserManager<ApplicationUser> userManager,IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }
        //Get Questions
        public async Task<IEnumerable<SecurityQuestion>> GetAllQuestionsAsync()
        {
            var repo = _unitOfWork.Repository<SecurityQuestion, int>();
            return await repo.GetAllAsync();
        }
        //set Question +Answer
        public async Task<bool> SetSecurityQuestionAsync(string userId, SetSecurityQuestionDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if(user ==null)
            {
                return false;
            }
            if(user.SecurityQuestionId !=null)
            {
                return false;
            }
            var result = await _userManager.UpdateAsync(user);
            return result.Succeeded;
        }
        public async Task<string?> ForgetPasswordAsync(ForgetPasswordDto forgetPasswordDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.LoginCode== forgetPasswordDto.LoginCode);
            if(user ==null || user.SecurityAnswerHash ==null)
            {
                return null;
            }
            var hashed = Hash(forgetPasswordDto.Answer);

            if (hashed != user.SecurityAnswerHash)
                return null;

            return await _userManager.GeneratePasswordResetTokenAsync(user);
        }
        public async Task<bool> ResetPasswordAsync(ResetPasswordDto dto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.LoginCode ==dto.LoginCode);
            if(user ==null)
            {
                return false;
            }
            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.NewPassword);
            return result.Succeeded;
        }
        private string Hash(string input)
        {
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input.Trim().ToLower());
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
