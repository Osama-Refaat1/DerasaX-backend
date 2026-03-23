using DerasaX.Application.Dto.SecurityQuestionDto;
using DerasaX.Application.Services.Abstractions.SecurityQuestions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityQuestionController : ControllerBase
    {
        private readonly ISecurityQuestionService _securityService;
        public SecurityQuestionController(ISecurityQuestionService securityService)
        {
            _securityService = securityService;
        }
        
        [HttpGet("GetQuestions")]
        //[Authorize]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await _securityService.GetAllQuestionsAsync();
            return Ok(questions);
        }

        [HttpPost("SetSecurityQuestion")]
        //[Authorize]
        public async Task<IActionResult> SetSecurityQuestion([FromBody] SetSecurityQuestionDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized("Invalid user");

            var result = await _securityService.SetSecurityQuestionAsync(userId, dto);

            if (!result)
                return BadRequest("Security question already set or failed");

            return Ok("Security question set successfully");
        }

        
        [HttpPost("ForgetPassword")]
        //[AllowAnonymous]
        public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDto forgetPasswordDto)
        {
            var token = await _securityService.ForgetPasswordAsync(forgetPasswordDto);

            if (token == null)
                return BadRequest("Invalid answer or user");

            return Ok(new
            {
                message = "Answer is correct",
                resetToken = token
            });
        }
        [HttpPost("ResetPassword")]
        //[AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto resetPasswordDto)
        {
            var result = await _securityService.ResetPasswordAsync(resetPasswordDto);

            if (!result)
                return BadRequest("Failed to reset password");

            return Ok("Password reset successfully");
        }
    }
}
