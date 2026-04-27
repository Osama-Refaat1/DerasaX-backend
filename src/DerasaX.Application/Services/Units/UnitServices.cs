using AutoMapper;
using DerasaX.Application.Dto.UnitDto;
using DerasaX.Application.Services.Abstractions.Unit;
using DerasaX.Application.Services.Image.FileServices;
using DerasaX.Application.Services.Subjects;
using DerasaX.Domain.Common;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Exceptions;
using DerasaX.Domain.Interfaces;
using DerasaX.Domain.Specification.Subjects;
using DerasaX.Domain.Specification.Units;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Units
{
    public class UnitServices : IUnitServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UnitServices> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UnitServices(IMapper mapper, IUnitOfWork unitOfWork, ILogger<UnitServices> logger , IHttpContextAccessor httpContextAccessor)
        {
            _mapper=mapper;
            _unitOfWork=unitOfWork;
            _logger=logger;
            _httpContextAccessor=httpContextAccessor;
        }
        private string GetTenantId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst("tenantId")?.Value;
        }
        public async Task<ApiResponse<IEnumerable<ReadUnitDto>>> GetUnitBySubjectIdAsync(string subjectId)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var unitSpecification = new UnitSpecification(subjectId,tenantId , true);
            var units = await _unitOfWork.Repository<Unit, string>().GetAllWithSpecAsync(unitSpecification);
            if (!units.Any())
            {
                _logger.LogError($"No units found in subject with ID {subjectId}.");
                throw new NotFoundException($"No units found in subject with ID {subjectId}.");
            }
            var unitDtos = _mapper.Map<IEnumerable<ReadUnitDto>>(units);
            return new ApiResponse<IEnumerable<ReadUnitDto>>(unitDtos)
            {
                Success = true,
                StatusCode = 200,
                Message = "Units retrieved successfully."
            };
        }
        public async Task<ApiResponse<ReadUnitDto>> AddUnitAsync(AddUnitDto addUnitDto)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (addUnitDto is null)
            {
                _logger.LogError("Invalid Unit data provided for addition");
                throw new BadRequestException("Invalid unit data provided");
            }

            var unit = _mapper.Map<Unit>(addUnitDto);
            unit.Id = Guid.NewGuid().ToString();
            unit.TenantId = tenantId;

            await _unitOfWork.Repository<Unit, string>().AddAsync(unit);
            await _unitOfWork.SaveChangesAsync();

            var unitDto = _mapper.Map<ReadUnitDto>(unit);

            _logger.LogInformation("Successfully added unit: {UnitTitle} with ID: {UnitId}",
                addUnitDto.Title, unit.Id);

            return new ApiResponse<ReadUnitDto>(unitDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Unit added successfully."
            };
        }
        public async Task<ApiResponse<ReadUnitDto>> UpdateUnitAsync(UpdateUnitDto updateUnitDto)
        {
            if (updateUnitDto is null)
            {
                _logger.LogWarning("Invalid unit data provided for update");
                throw new BadRequestException("Invalid unit data provided");
            }

            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Updating unit with ID: {UnitId}, TenantId: {TenantId}",
                updateUnitDto.Id, tenantId);

            var spec = new UnitSpecification(updateUnitDto.Id, tenantId);
            var existingUnit = await _unitOfWork.Repository<Unit, string>()
                .GetByIdWithSpecAsync(spec);

            if (existingUnit is null)
            {
                _logger.LogWarning("Unit not found for update with ID: {UnitId}", updateUnitDto.Id);
                throw new NotFoundException("Unit not found.");
            }

            _mapper.Map(updateUnitDto, existingUnit);

            existingUnit.TenantId = tenantId;

            await _unitOfWork.SaveChangesAsync();

            var unitDto = _mapper.Map<ReadUnitDto>(existingUnit);

            _logger.LogInformation("Successfully updated unit with ID: {UnitId}", updateUnitDto.Id);

            return new ApiResponse<ReadUnitDto>(unitDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Unit updated successfully."
            };
        }
        public async Task<ApiResponse<bool>> DeleteUnit(string id)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Deleting Unit with ID: {UnitId}, TenantId: {TenantId}", id, tenantId);

            var spec = new UnitSpecification(id, tenantId);

            var unit = await _unitOfWork.Repository<Unit, string>()
                .GetByIdWithSpecAsync(spec);

            if (unit == null)
            {
                _logger.LogWarning("Unit not found for deletion with ID: {UnitId}", id);
                throw new NotFoundException($"Unit with ID {id} not found.");
            }

            _unitOfWork.Repository<Unit, string>().Delete(unit);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Successfully deleted Unit with ID: {UnitId}", id);

            return new ApiResponse<bool>(true)
            {
                Success = true,
                StatusCode = 200,
                Message = "Unit deleted successfully."
            };
        }
    }
}
