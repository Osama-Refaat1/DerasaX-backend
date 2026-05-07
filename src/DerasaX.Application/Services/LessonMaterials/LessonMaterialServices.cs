using AutoMapper;
using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.LessonMaterialDto;
using DerasaX.Application.Services.Abstractions.LessonMaterial;
using DerasaX.Application.Services.Units;
using DerasaX.Domain.Common;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Exceptions;
using DerasaX.Domain.Interfaces;
using DerasaX.Domain.Specification.Lessons;
using DerasaX.Domain.Specification.LessonsMaterial;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.LessonMaterials
{
    public class LessonMaterialServices : ILessonMaterialServicess
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LessonMaterialServices> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LessonMaterialServices(IMapper mapper, IUnitOfWork unitOfWork, ILogger<LessonMaterialServices> logger, IHttpContextAccessor httpContextAccessor)
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
        public async Task<ApiResponse<IEnumerable<GetLessonMaterialDto>>> GetMaterialByLessonIdAsync(string lessonId)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var lessonMaterialSpecification = new LessonMaterialSpecification(lessonId, tenantId, true);
            var material = await _unitOfWork.Repository<LessonMaterial, string>().GetAllWithSpecAsync(lessonMaterialSpecification);
            if (!material.Any())
            {
                _logger.LogError($"No Material found in lesson with ID {lessonId}.");
                throw new NotFoundException($"No Material found in lesson with ID {lessonId}.");
            }
            var MaterialDtos = _mapper.Map<IEnumerable<GetLessonMaterialDto>>(material);
            return new ApiResponse<IEnumerable<GetLessonMaterialDto>>(MaterialDtos)
            {
                Success = true,
                StatusCode = 200,
                Message = "Material retrieved successfully."
            };
        }
        public async Task<ApiResponse<GetLessonMaterialDto>> AddMaterialAsync(AddLessonMaterialDto addLessonMaterialDto)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (addLessonMaterialDto is null)
            {
                _logger.LogError("Invalid material data provided for addition");
                throw new BadRequestException("Invalid material data provided");
            }

            var material = _mapper.Map<LessonMaterial>(addLessonMaterialDto);
            material.Id = Guid.NewGuid().ToString();
            material.TenantId = tenantId;

            await _unitOfWork.Repository<LessonMaterial, string>().AddAsync(material);
            await _unitOfWork.SaveChangesAsync();

            var materialDto = _mapper.Map<GetLessonMaterialDto>(material);

            _logger.LogInformation("Successfully added material with ID: {materialId}", material.Id);

            return new ApiResponse<GetLessonMaterialDto>(materialDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Material added successfully."
            };
        }
        public async Task<ApiResponse<GetLessonMaterialDto>> UpdateMaterialAsync(GetLessonMaterialDto getLessonMaterialDto)
        {
            if (getLessonMaterialDto is null)
            {
                _logger.LogWarning("Invalid material data provided for update");
                throw new BadRequestException("Invalid material data provided");
            }

            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Updating material with ID: {materialId}, TenantId: {TenantId}",
                getLessonMaterialDto.Id, tenantId);

            var spec = new LessonMaterialSpecification(getLessonMaterialDto.Id, tenantId);
            var existingMaterial = await _unitOfWork.Repository<LessonMaterial, string>()
                .GetByIdWithSpecAsync(spec);

            if (existingMaterial is null)
            {
                _logger.LogWarning("Material not found for update with ID: {MaterialId}", getLessonMaterialDto.Id);
                throw new NotFoundException("Material not found.");
            }

            _mapper.Map(getLessonMaterialDto, existingMaterial);

            existingMaterial.TenantId = tenantId;

            await _unitOfWork.SaveChangesAsync();

            var materialDto = _mapper.Map<GetLessonMaterialDto>(existingMaterial);

            _logger.LogInformation("Successfully updated Material with ID: {MaterialId}", getLessonMaterialDto.Id);

            return new ApiResponse<GetLessonMaterialDto>(materialDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Material updated successfully."
            };
        }
        public async Task<ApiResponse<bool>> DeleteMaterial(string id)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Deleting material with ID: {materialId}, TenantId: {TenantId}", id, tenantId);

            var spec = new LessonMaterialSpecification(id, tenantId);

            var material = await _unitOfWork.Repository<LessonMaterial, string>()
                .GetByIdWithSpecAsync(spec);

            if (material == null)
            {
                _logger.LogWarning("material not found for deletion with ID: {materialId}", id);
                throw new NotFoundException($"material with ID {id} not found.");
            }

            _unitOfWork.Repository<LessonMaterial, string>().Delete(material);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Successfully deleted material with ID: {materialId}", id);

            return new ApiResponse<bool>(true)
            {
                Success = true,
                StatusCode = 200,
                Message = "Material deleted successfully."
            };
        }
    }
}
