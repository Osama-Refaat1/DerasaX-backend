using DerasaX.Application.Dto.GradeDto;
using DerasaX.Application.Services.Abstractions.Grade;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly IGradeServices _gradeServices;
        private readonly ILogger<GradesController> _logger;

        public GradesController (IGradeServices gradeServices , ILogger<GradesController> logger)
        {
            _gradeServices=gradeServices;
            _logger=logger;
        }
        [HttpGet("GetAllGrades")]
        public async Task<IActionResult> GetAllGrades()
        {
            _logger.LogInformation("Getting all grades");

            var result = await _gradeServices.GetAllGradeAsync();

            _logger.LogInformation("Successfully retrieved all grades");

            return Ok(result);
        }
        [HttpGet("GetGradeById")]
        public async Task<IActionResult> GetGradeById(string id)
        {
            _logger.LogInformation("Getting Grade by ID: {GradeId}", id);

            var result = await _gradeServices.GetGradeByIdAsync(id);

            _logger.LogInformation("Successfully retrieved Grade with ID: {GradeId}", id);

            return Ok(result);
        }
        [HttpPost("AddGrade")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddGrade([FromBody] AddGradeDto gradeDto)
        {
            _logger.LogInformation("Adding new Grade");

            var result = await _gradeServices.AddGradeAsync(gradeDto);

            _logger.LogInformation("Successfully added Grade with ID: {GradeId}", result.Data?.Id);

            return Ok(result);
        }
        [HttpPut("UpdateGrade")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateGrade([FromBody] GetGradeDto gradeDto)
        {
            _logger.LogInformation("Updating Grade with ID: {GradeId}", gradeDto.Id);

            var result = await _gradeServices.UpdateGradeAsync(gradeDto);

            _logger.LogInformation("Successfully updated Grade with ID: {GradeId}", gradeDto.Id);

            return Ok(result);
        }
        [HttpDelete("DeleteGrade")]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteGrade(string id)
        {
            _logger.LogInformation("Deleting Grade with ID: {GradeId}", id);

            var result = await _gradeServices.DeleteGrade(id);

            _logger.LogInformation("Successfully deleted Grade with ID: {GradeId}", id);

            return Ok(result);
        }
    }
}

