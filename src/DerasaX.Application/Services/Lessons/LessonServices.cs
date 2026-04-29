using AutoMapper;
using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.UnitDto;
using DerasaX.Application.Services.Abstractions.Lesson;
using DerasaX.Application.Services.Units;
using DerasaX.Domain.Common;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Exceptions;
using DerasaX.Domain.Interfaces;
using DerasaX.Domain.Specification.Lessons;
using DerasaX.Domain.Specification.Units;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Lessons
{
    public class LessonServices : ILessonServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UnitServices> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LessonServices(IMapper mapper, IUnitOfWork unitOfWork, ILogger<UnitServices> logger, IHttpContextAccessor httpContextAccessor)
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
        public async Task<ApiResponse<IEnumerable<GetLessonDto>>> GetLessonByUnitIdAsync(string unitId)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var LessonSpecification = new LessonSpecification(unitId, tenantId, true);
            var lessons = await _unitOfWork.Repository<Lesson, string>().GetAllWithSpecAsync(LessonSpecification);
            if (!lessons.Any())
            {
                _logger.LogError($"No lessons found in unit with ID {unitId}.");
                throw new NotFoundException($"No lessons found in unit with ID {unitId}.");
            }
            var lessonDtos = _mapper.Map<IEnumerable<GetLessonDto>>(lessons);
            return new ApiResponse<IEnumerable<GetLessonDto>>(lessonDtos)
            {
                Success = true,
                StatusCode = 200,
                Message = "Lessons retrieved successfully."
            };
        }
        public async Task<ApiResponse<GetLessonDto>> AddLessonAsync(AddLessonDto addLessonDto)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (addLessonDto is null)
            {
                _logger.LogError("Invalid lesson data provided for addition");
                throw new BadRequestException("Invalid lesson data provided");
            }

            var lesson = _mapper.Map<Lesson>(addLessonDto);
            lesson.Id = Guid.NewGuid().ToString();
            lesson.TenantId = tenantId;

            await _unitOfWork.Repository<Lesson, string>().AddAsync(lesson);
            await _unitOfWork.SaveChangesAsync();

            var lessonDto = _mapper.Map<GetLessonDto>(lesson);

            _logger.LogInformation("Successfully added Lesson with ID: {LessonId}",lesson.Id);

            return new ApiResponse<GetLessonDto>(lessonDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Lesson added successfully."
            };
        }
        public async Task<ApiResponse<GetLessonDto>> UpdateLessonAsync(GetLessonDto getLessonDto)
        {
            if (getLessonDto is null)
            {
                _logger.LogWarning("Invalid lesson data provided for update");
                throw new BadRequestException("Invalid lesson data provided");
            }

            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Updating Lesson with ID: {lessonId}, TenantId: {TenantId}",
                getLessonDto.Id, tenantId);

            var spec = new LessonSpecification(getLessonDto.Id, tenantId);
            var existingLesson = await _unitOfWork.Repository<Lesson, string>()
                .GetByIdWithSpecAsync(spec);

            if (existingLesson is null)
            {
                _logger.LogWarning("Lesson not found for update with ID: {LessonId}", getLessonDto.Id);
                throw new NotFoundException("Lesson not found.");
            }

            _mapper.Map(getLessonDto, existingLesson);

            existingLesson.TenantId = tenantId;

            await _unitOfWork.SaveChangesAsync();

            var lessonDto = _mapper.Map<GetLessonDto>(existingLesson);

            _logger.LogInformation("Successfully updated lesson with ID: {lessonId}", getLessonDto.Id);

            return new ApiResponse<GetLessonDto>(lessonDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Lesson updated successfully."
            };
        }
        public async Task<ApiResponse<bool>> DeleteLesson(string id)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Deleting Lesson with ID: {lessonId}, TenantId: {TenantId}", id, tenantId);

            var spec = new LessonSpecification(id, tenantId);

            var lesson = await _unitOfWork.Repository<Lesson, string>()
                .GetByIdWithSpecAsync(spec);

            if (lesson == null)
            {
                _logger.LogWarning("Lesson not found for deletion with ID: {LessonId}", id);
                throw new NotFoundException($"Lesson with ID {id} not found.");
            }

            _unitOfWork.Repository<Lesson, string>().Delete(lesson);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Successfully deleted lesson with ID: {lessonId}", id);

            return new ApiResponse<bool>(true)
            {
                Success = true,
                StatusCode = 200,
                Message = "Lesson deleted successfully."
            };
        }
    }
}
