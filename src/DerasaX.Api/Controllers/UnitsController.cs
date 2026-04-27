using DerasaX.Application.Dto.UnitDto;
using DerasaX.Application.Services.Abstractions.Unit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DerasaX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitServices _unitServices;
        private readonly ILogger<UnitsController> _logger;
        public UnitsController(IUnitServices unitServices , ILogger<UnitsController> logger)
        {
            _unitServices=unitServices;
            _logger=logger;
        }
        [HttpGet("GetUnitsBySubjectId")]
        //[AllowAnonymous] // Public endpoint - anyone can view hotels by region
        public async Task<IActionResult> GetUnitsBySubjectId(string id)
        {
            _logger.LogInformation("Getting hotels by region ID: {RegionId}", id);

            var result = await _unitServices.GetUnitBySubjectIdAsync(id);

            _logger.LogInformation("Successfully retrieved units for subject ID: {subjectId}", id);
            return Ok(result);
        }

        [HttpPost("AddUnit")]
        //[Authorize(Roles = "Admin")] // Only Admin can add hotels
        public async Task<IActionResult> AddUnit([FromForm] AddUnitDto addUnitDto)
        {
            _logger.LogInformation("Adding new Unit: {UnitName}", addUnitDto.Title);

            var result = await _unitServices.AddUnitAsync(addUnitDto);

            _logger.LogInformation("Successfully added unit: {UnitTitle} with ID: {UnitId}",
                addUnitDto.Title , result.Data?.Id);
            return Ok(result);
        }

        [HttpPut("UpdateUnit")]
        //[Authorize(Roles = "Admin")] // Only Admin can update hotels
        public async Task<IActionResult> UpdateUnit([FromForm] UpdateUnitDto updateUnitDto)
        {
            _logger.LogInformation("Updating unit with ID: {unitId}", updateUnitDto.Id);

            var result = await _unitServices.UpdateUnitAsync(updateUnitDto);

            _logger.LogInformation("Successfully updated hotel with ID: {HotelId}", updateUnitDto.Id);
            return Ok(result);
        }

        [HttpDelete("DeleteUnit")]
        //[Authorize(Roles = "Admin")] // Only Admin can delete hotels
        public async Task<IActionResult> DeleteUnit(string id)
        {
            _logger.LogInformation("Deleting unit with ID: {unitId}", id);

            var result = await _unitServices.DeleteUnit(id);

            _logger.LogInformation("Successfully deleted unit with ID: {unitId}", id);
            return Ok(result);
        }
    }
}
