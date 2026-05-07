using AutoMapper;
using DerasaX.Application.Dto.GradeDto;
using DerasaX.Application.Dto.QuizDto;
using DerasaX.Application.Services.Abstractions.Quiz;
using DerasaX.Application.Services.Grades;
using DerasaX.Domain.Common;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Enums;
using DerasaX.Domain.Exceptions;
using DerasaX.Domain.Interfaces;
using DerasaX.Domain.Specification.Grades;
using DerasaX.Domain.Specification.Quizs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Quizzes
{
    public class QuizServices : IQuizServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QuizServices> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public QuizServices(IMapper mapper, IUnitOfWork unitOfWork, ILogger<QuizServices> logger, IHttpContextAccessor httpContextAccessor)
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
        public async Task<ApiResponse<IEnumerable<GetQuizDto>>> GetAllQuizzesAsync()
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var spec = new QuizSpecification(tenantId);
            var quizzes = await _unitOfWork.Repository<Quiz, string>()
                .GetAllWithSpecAsync(spec);

            if (!quizzes.Any())
            {
                _logger.LogWarning("No quizzes found for tenant {TenantId}", tenantId);
                throw new NotFoundException("No quizzes found.");
            }

            var dto = _mapper.Map<IEnumerable<GetQuizDto>>(quizzes);

            return new ApiResponse<IEnumerable<GetQuizDto>>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Quizzes retrieved successfully."
            };
        }
        public async Task<ApiResponse<GetQuizDto>> GetQuizByIdAsync(string id)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var spec = new QuizSpecification(id, tenantId);
            var quiz = await _unitOfWork.Repository<Quiz, string>()
                .GetByIdWithSpecAsync(spec);

            if (quiz == null)
            {
                _logger.LogWarning("quiz not found: {GradeId}", id);
                throw new NotFoundException("quiz not found.");
            }

            var dto = _mapper.Map<GetQuizDto>(quiz);

            return new ApiResponse<GetQuizDto>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "quiz retrieved successfully."
            };
        }
        public async Task<ApiResponse<IEnumerable<GetQuizDto>>> GetQuizzesByTypeAsync(string referenceId, QuizType type)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            
            ValidateQuizType(referenceId, type);

            var spec = new QuizSpecification(referenceId, tenantId, type);

            var quizzes = await _unitOfWork.Repository<Quiz, string>()
                .GetAllWithSpecAsync(spec);

            if (quizzes == null || !quizzes.Any())
            {
                _logger.LogWarning("No quizzes found for referenceId: {ReferenceId}, type: {Type}", referenceId, type);
                throw new NotFoundException("No quizzes found.");
            }

            var dto = _mapper.Map<IEnumerable<GetQuizDto>>(quizzes);

            return new ApiResponse<IEnumerable<GetQuizDto>>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Quizzes retrieved successfully."
            };
        }
        public async Task<ApiResponse<GetQuizDto>> CreateQuizAsync(AddQuizDto addQuizDto)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (addQuizDto == null)
                throw new BadRequestException("Invalid quiz data.");

            var quiz = _mapper.Map<Quiz>(addQuizDto);

            quiz.Id = Guid.NewGuid().ToString();
            quiz.TenantId = tenantId;

            await _unitOfWork.Repository<Quiz, string>().AddAsync(quiz);
            await _unitOfWork.SaveChangesAsync();

            var dto = _mapper.Map<GetQuizDto>(quiz);

            _logger.LogInformation("Quiz created with Id {GradeId}", quiz.Id);

            return new ApiResponse<GetQuizDto>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Quiz added successfully."
            };
        }
        public async Task<ApiResponse<GetQuizDto>> UpdateQuizAsync(GetQuizDto getQuizDto)
        {
            var tenantId = GetTenantId();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (getQuizDto == null)
                throw new BadRequestException("Invalid quiz data.");

            var spec = new QuizSpecification(getQuizDto.Id, tenantId);

            var existing = await _unitOfWork.Repository<Quiz, string>()
                .GetByIdWithSpecAsync(spec);

            if (existing == null)
            {
                _logger.LogWarning("Quiz not found: {QuizId}", getQuizDto.Id);
                throw new NotFoundException("Quiz not found.");
            }

            _mapper.Map(getQuizDto, existing);

            existing.TenantId = tenantId;

            await _unitOfWork.SaveChangesAsync();

            var dto = _mapper.Map<GetQuizDto>(existing);

            return new ApiResponse<GetQuizDto>(dto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Quiz updated successfully."
            };
        }
        public async Task<ApiResponse<bool>> DeleteQuizAsync(string id)
        {
            var tenantId = GetTenantId();

            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var spec = new QuizSpecification(id, tenantId);

            var quiz = await _unitOfWork.Repository<Quiz, string>()
                .GetByIdWithSpecAsync(spec);

            if (quiz == null)
            {
                _logger.LogWarning("Quiz not found for deletion: {QuizId}", id);
                throw new NotFoundException("Quiz not found.");
            }

            _unitOfWork.Repository<Quiz, string>().Delete(quiz);
            await _unitOfWork.SaveChangesAsync();

            return new ApiResponse<bool>(true)
            {
                Success = true,
                StatusCode = 200,
                Message = "Quiz deleted successfully."
            };
        }
        private void ValidateQuizType(string referenceId, QuizType type)
        {
            if (type == QuizType.Lesson && string.IsNullOrEmpty(referenceId))
                throw new BadRequestException("LessonId is required for Lesson quizzes.");

            if (type == QuizType.Final && string.IsNullOrEmpty(referenceId))
                throw new BadRequestException("SubjectId is required for Final quizzes.");
        }
    }
}
