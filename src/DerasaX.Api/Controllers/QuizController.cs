using DerasaX.Application.Dto.GradeDto;
using DerasaX.Application.Dto.QuizDto;
using DerasaX.Application.Services.Abstractions.Quiz;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizServices _quizServices;
        private readonly ILogger<QuizController> _logger;
        public QuizController(IQuizServices quizServices ,ILogger<QuizController> logger)
        {
            _quizServices=quizServices;
            _logger=logger;
        }
        [HttpGet("GetAllQuizzes")]
        public async Task<IActionResult> GetAllQuizzes()
        {
            _logger.LogInformation("Getting all Quizzes");

            var result = await _quizServices.GetAllQuizzesAsync();

            _logger.LogInformation("Successfully retrieved all Quizzes");

            return Ok(result);
        }
        [HttpGet("GetQuizById")]
        public async Task<IActionResult> GetQuizById(string id)
        {
            _logger.LogInformation("Getting quiz by ID: {QuizId}", id);

            var result = await _quizServices.GetQuizByIdAsync(id);

            _logger.LogInformation("Successfully retrieved quiz with ID: {QuizId}", id);

            return Ok(result);
        }
        [HttpGet("GetQuizzesByType")]
        public async Task<IActionResult> GetQuizzesByType(string referenceId, QuizType type)
        {
            _logger.LogInformation("Getting quiz by ID: {QuizId}", referenceId);

            var result = await _quizServices.GetQuizzesByTypeAsync(referenceId,type);

            _logger.LogInformation("Successfully retrieved quiz with ID: {QuizId}", referenceId);

            return Ok(result);
        }
        [HttpPost("AddQuiz")]
        public async Task<IActionResult> AddQuiz([FromBody] AddQuizDto addQuizDto)
        {
            _logger.LogInformation("Adding new quiz");

            var result = await _quizServices.CreateQuizAsync(addQuizDto);

            _logger.LogInformation("Successfully added quiz with ID: {QuizId}", result.Data?.Id);

            return Ok(result);
        }
        [HttpPut("UpdateQuiz")]
        public async Task<IActionResult> UpdateQuiz([FromBody] GetQuizDto getQuizDto)
        {
            _logger.LogInformation("Updating quiz with ID: {quizId}", getQuizDto.Id);

            var result = await _quizServices.UpdateQuizAsync(getQuizDto);

            _logger.LogInformation("Successfully updated quiz with ID: {quizId}", getQuizDto.Id);

            return Ok(result);
        }
        [HttpDelete("DeleteQuiz")]
        public async Task<IActionResult> DeleteQuiz(string id)
        {
            _logger.LogInformation("Deleting quiz with ID: {QuizId}", id);

            var result = await _quizServices.DeleteQuizAsync(id);

            _logger.LogInformation("Successfully deleted quiz with ID: {QuizId}", id);

            return Ok(result);
        }
    }
}
