using DerasaX.Application.Dto.SubjectDto;
using DerasaX.Application.Services.Abstractions.Subject;
using DerasaX.Domain.Specification.Subjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectServices _subjectServices;
        private readonly ILogger<SubjectsController> _logger;
        public SubjectsController(ISubjectServices subjectServices, ILogger<SubjectsController> logger)
        {
            _subjectServices=subjectServices;
            _logger=logger;
        }
        [HttpGet("GetSubjects")]
        public async Task<IActionResult> GetSubjects([FromQuery] SubjectsParameters parameters)
        {
            _logger.LogInformation("Getting subjects with parameters: PageNumber={PageNumber}, PageSize={PageSize}",
                parameters.PageNumber, parameters.PageSize);

            var subjects = await _subjectServices.GetSubjectsAsync(parameters);

            _logger.LogInformation("Successfully retrieved {Count} subjects", subjects.Data?.Count() ?? 0);

            return Ok(subjects);
        }
        [HttpGet("GetSubjectById/{id}")]
        public async Task<IActionResult> GetSubjectById(string id)
        {
            _logger.LogInformation("Getting subject by ID: {SubjectId}", id);

            var subject = await _subjectServices.GetSubjectByIdAsync(id);

            _logger.LogInformation("Successfully retrieved subject with ID: {SubjectId}", id);

            return Ok(subject);
        }
        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromForm] AddSubjectDto addSubjectDto)
        {
            _logger.LogInformation("Adding new subject: {SubjectName}", addSubjectDto.Name);

            var result = await _subjectServices.AddSubjectAsync(addSubjectDto);

            _logger.LogInformation("Successfully added subject: {SubjectName} with ID: {SubjectId}", addSubjectDto.Name, result.Data?.Id);

            return Ok(result); 
        }
        [HttpPut("UpdateSubject")]
        public async Task<IActionResult> UpdateSubject([FromForm] UpdateSubjectDto updateSubjectDto)
        {
            _logger.LogInformation("Updating subject with ID: {SubjectId}", updateSubjectDto.Id);

            var result = await _subjectServices.UpdateSubjectAsync(updateSubjectDto);

            _logger.LogInformation("Successfully updated subject with ID: {SubjectId}", updateSubjectDto.Id);

            return Ok(result);
        }
        [HttpDelete("DeleteSubject/{id}")]
        public async Task<IActionResult> DeleteSubject(string id)
        {
            _logger.LogInformation("Deleting subject with ID: {SubjectId}", id);

            var result = await _subjectServices.DeleteSubject(id);

            _logger.LogInformation("Successfully deleted subject with ID: {SubjectId}", id);

            return Ok(result);
        }
    }
}
