using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.LessonMaterialDto;
using DerasaX.Application.Services.Abstractions.LessonMaterial;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonMaterialController : ControllerBase
    {
        private readonly ILessonMaterialServicess _lessonMaterialServicess;
        private readonly ILogger<LessonMaterialController> _logger;

        public LessonMaterialController(ILessonMaterialServicess lessonMaterialServicess , ILogger<LessonMaterialController> logger )
        {
            _lessonMaterialServicess=lessonMaterialServicess;
            _logger=logger;
        }
        [HttpGet("GetMaterialByLessonId")]
        public async Task<IActionResult> GetMaterialByLessonId(string id)
        {
            _logger.LogInformation("Getting material by lesson ID: {lessonId}", id);

            var result = await _lessonMaterialServicess.GetMaterialByLessonIdAsync(id);

            _logger.LogInformation("Successfully retrieved material for lesson ID: {unitId}", id);
            return Ok(result);
        }
        [HttpPost("AddMaterial")]
        public async Task<IActionResult> AddMaterial([FromForm] AddLessonMaterialDto lessonMaterialDto)
        {
            _logger.LogInformation("Adding Material");

            var result = await _lessonMaterialServicess.AddMaterialAsync(lessonMaterialDto);

            _logger.LogInformation("Successfully added material with ID: {materialId}", result.Data?.Id);
            return Ok(result);
        }

        [HttpPut("UpdateMaterial")]
        public async Task<IActionResult> UpdateMaterial([FromForm] GetLessonMaterialDto getLessonMaterialDto)
        {
            _logger.LogInformation("Updating material with ID: {mterialId}", getLessonMaterialDto.Id);

            var result = await _lessonMaterialServicess.UpdateMaterialAsync(getLessonMaterialDto);

            _logger.LogInformation("Successfully updated material with ID: {materialId}", getLessonMaterialDto.Id);
            return Ok(result);
        }

        [HttpDelete("DeleteMaterial")]
        public async Task<IActionResult> DeleteMaterial(string id)
        {
            _logger.LogInformation("Deleting material with ID: {MaterialId}", id);

            var result = await _lessonMaterialServicess.DeleteMaterial(id);

            _logger.LogInformation("Successfully deleted material with ID: {materialId}", id);
            return Ok(result);
        }
    }
}
