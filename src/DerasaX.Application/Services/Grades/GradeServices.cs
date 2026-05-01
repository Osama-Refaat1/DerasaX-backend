using AutoMapper;
using DerasaX.Application.Dto.GradeDto;
using DerasaX.Application.Services.Abstractions.Grade;
using DerasaX.Application.Services.Units;
using DerasaX.Domain.Common;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Exceptions;
using DerasaX.Domain.Interfaces;
using DerasaX.Domain.Specification.Grades;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Grades
{
    public class GradeServices : IGradeServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GradeServices> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GradeServices(IMapper mapper, IUnitOfWork unitOfWork, ILogger<GradeServices> logger, IHttpContextAccessor httpContextAccessor)
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
        public async Task<ApiResponse<IEnumerable<GetGradeDto>>> GetAllGradeAsync()
        {
            var tenantId = GetTenantId();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var spec = new GradeSpecification(tenantId);

            var grades = await _unitOfWork.Repository<Grade, string>()
                .GetAllWithSpecAsync(spec);

            if (!grades.Any())
            {
                _logger.LogWarning("No grades found for tenant {TenantId}", tenantId);
                throw new NotFoundException("No grades found.");
            }

            var dto = _mapper.Map<IEnumerable<GetGradeDto>>(grades);

            return new ApiResponse<IEnumerable<GetGradeDto>>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Grades retrieved successfully."
            };
        }
        public async Task<ApiResponse<GetGradeDto>> GetGradeByIdAsync(string id)
        {
            var tenantId = GetTenantId();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var spec = new GradeSpecification(id, tenantId);

            var grade = await _unitOfWork.Repository<Grade, string>()
                .GetByIdWithSpecAsync(spec);

            if (grade == null)
            {
                _logger.LogWarning("Grade not found: {GradeId}", id);
                throw new NotFoundException("Grade not found.");
            }

            var dto = _mapper.Map<GetGradeDto>(grade);

            return new ApiResponse<GetGradeDto>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Grade retrieved successfully."
            };
        }
        public async Task<ApiResponse<GetGradeDto>> AddGradeAsync(AddGradeDto addGradeDto)
        {
            var tenantId = GetTenantId();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (addGradeDto == null)
                throw new BadRequestException("Invalid grade data.");

            var grade = _mapper.Map<Grade>(addGradeDto);

            grade.Id = Guid.NewGuid().ToString();
            grade.TenantId = tenantId;

            await _unitOfWork.Repository<Grade, string>().AddAsync(grade);
            await _unitOfWork.SaveChangesAsync();

            var dto = _mapper.Map<GetGradeDto>(grade);

            _logger.LogInformation("Grade created with Id {GradeId}", grade.Id);

            return new ApiResponse<GetGradeDto>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Grade added successfully."
            };
        }
        public async Task<ApiResponse<GetGradeDto>> UpdateGradeAsync(GetGradeDto getGradeDto)
        {
            var tenantId = GetTenantId();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (getGradeDto == null)
                throw new BadRequestException("Invalid grade data.");

            var spec = new GradeSpecification(getGradeDto.Id, tenantId);

            var existing = await _unitOfWork.Repository<Grade, string>()
                .GetByIdWithSpecAsync(spec);

            if (existing == null)
            {
                _logger.LogWarning("Grade not found: {GradeId}", getGradeDto.Id);
                throw new NotFoundException("Grade not found.");
            }

            _mapper.Map(getGradeDto, existing);

            existing.TenantId = tenantId;

            await _unitOfWork.SaveChangesAsync();

            var dto = _mapper.Map<GetGradeDto>(existing);

            return new ApiResponse<GetGradeDto>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Grade updated successfully."
            };
        }
        public async Task<ApiResponse<bool>> DeleteGrade(string id)
        {
            var tenantId = GetTenantId();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var spec = new GradeSpecification(id, tenantId);

            var grade = await _unitOfWork.Repository<Grade, string>()
                .GetByIdWithSpecAsync(spec);

            if (grade == null)
            {
                _logger.LogWarning("Grade not found for deletion: {GradeId}", id);
                throw new NotFoundException("Grade not found.");
            }

            _unitOfWork.Repository<Grade, string>().Delete(grade);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse<bool>(true)
            {
                Success = true,
                StatusCode = 200,
                Message = "Grade deleted successfully."
            };
        }
       
    }
}
