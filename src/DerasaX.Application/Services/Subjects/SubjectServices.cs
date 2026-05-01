using AutoMapper;
using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.SubjectDto;
using DerasaX.Application.Services.Abstractions.Subject;
using DerasaX.Application.Services.Image.FileServices;
using DerasaX.Domain.Common;
using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Exceptions;
using DerasaX.Domain.Interfaces;
using DerasaX.Domain.Specification.Subjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Subjects
{
    public class SubjectServices : ISubjectServices
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SubjectServices> _logger;
        private readonly IFileService _fileService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SubjectServices(IMapper mapper, IUnitOfWork unitOfWork, ILogger<SubjectServices> logger, IFileService fileService, IHttpContextAccessor httpContextAccessor)
        {
            _mapper=mapper;
            _unitOfWork=unitOfWork;
            _logger=logger;
            _fileService=fileService;
            _httpContextAccessor = httpContextAccessor;
        }
        private string GetTenantId()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst("tenantId")?.Value;
        }
        public async Task<PaginationResponse<IEnumerable<ReadSubjectDto>>> GetSubjectsAsync(SubjectsParameters parameters)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            if (parameters.PageNumber <= 0)
                throw new BadRequestException("PageNumber must be greater than 0.");

            if (parameters.PageSize <= 0)
                throw new BadRequestException("PageSize must be greater than 0.");

            var dataSpec = new SubjectsSpecification(parameters,tenantId);
            var countSpec = new SubjectForCountingSpecification(parameters,tenantId);
            var subjects = await _unitOfWork.Repository<Subject, string>().GetAllWithSpecAsync(dataSpec);
            var totalCount = await _unitOfWork.Repository<Subject, string>().CountAsync(countSpec);

            if (subjects == null || !subjects.Any())
            {
                _logger.LogWarning("No Subject found matching the provided criteria.");
                throw new NotFoundException("No Subject found matching the provided criteria.");
            }
            var subjectsDto = _mapper.Map<IEnumerable<ReadSubjectDto>>(subjects);

            return new PaginationResponse<IEnumerable<ReadSubjectDto>>(subjectsDto, totalCount, parameters.PageNumber,
                parameters.PageSize);
        }
        public async Task<ApiResponse<ReadSubjectDto>> GetSubjectByIdAsync(string id)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var subjectsSpecifications = new SubjectsSpecification(id, tenantId);
            var subject = await _unitOfWork.Repository<Subject, string>().GetByIdWithSpecAsync(subjectsSpecifications);
            if (subject is null)
            {
                _logger.LogError($"Subject with ID {id} not found.");
                throw new NotFoundException($"Subject with ID {id} not found.");
            }

            var subjectDto = _mapper.Map<ReadSubjectDto>(subject);
            _logger.LogInformation("Successfully retrieved Subject with ID: {subjectId}", id);
            return new ApiResponse<ReadSubjectDto>(subjectDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Subject retrieved successfully."
            };
        }
        public async Task<ApiResponse<IEnumerable<ReadSubjectDto>>> GetSubjectsByGradeIdAsync(string gradeId)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            var subjectSpecification = new SubjectsSpecification(gradeId, tenantId, true);
            var subjects = await _unitOfWork.Repository<Subject, string>().GetAllWithSpecAsync(subjectSpecification);
            if (!subjects.Any())
            {
                _logger.LogError($"No subjects found in unit with ID {gradeId}.");
                throw new NotFoundException($"No subjects found in unit with ID {gradeId}.");
            }
            var subjectDtos = _mapper.Map<IEnumerable<ReadSubjectDto>>(subjects);
            return new ApiResponse<IEnumerable<ReadSubjectDto>>(subjectDtos)
            {
                Success = true,
                StatusCode = 200,
                Message = "Subjects retrieved successfully."
            };
        }
        public async Task<ApiResponse<ReadSubjectDto>> AddSubjectAsync(AddSubjectDto addSubjectDto)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");
            if (addSubjectDto is null)
            {
                _logger.LogError("Invalid Subject data provided for addition");
                throw new BadRequestException("Invalid subject data provided");
            }

            string imagePath = null;
            if (addSubjectDto.ImageUrl != null && addSubjectDto.ImageUrl.Length > 0)
            {
                _logger.LogDebug("Uploading image for subject: {SubjectName}", addSubjectDto.Name);
                imagePath = await _fileService.UploadImageAsync(addSubjectDto.ImageUrl, "Subjects");
                _logger.LogDebug("Image uploaded successfully: {ImagePath}", imagePath);
            }

            var subject = _mapper.Map<Subject>(addSubjectDto);
            subject.Id = Guid.NewGuid().ToString();
            subject.ImageUrl = imagePath;
            subject.TenantId = tenantId;

            await _unitOfWork.Repository<Subject, string>().AddAsync(subject);
            await _unitOfWork.SaveChangesAsync();

            var subjectDto = _mapper.Map<ReadSubjectDto>(subject);
            _logger.LogInformation("Successfully added subject: {SubjectName} with ID: {SubjectId}", addSubjectDto.Name, subject.Id);

            return new ApiResponse<ReadSubjectDto>(subjectDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Subject added successfully."
            };
        }
        public async Task<ApiResponse<ReadSubjectDto>> UpdateSubjectAsync(UpdateSubjectDto updateSubjectDto)
        {
            if (updateSubjectDto is null)
            {
                _logger.LogWarning("Invalid subject data provided for update");
                throw new BadRequestException("Invalid subject data provided");
            }

            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Updating subject with ID: {SubjectId}, TenantId: {TenantId}", updateSubjectDto.Id, tenantId);

            var spec = new SubjectsSpecification(updateSubjectDto.Id, tenantId);
            var existingSubject = await _unitOfWork.Repository<Subject, string>()
                .GetByIdWithSpecAsync(spec);

            if (existingSubject is null)
            {
                _logger.LogWarning("Subject not found for update with ID: {SubjectId}", updateSubjectDto.Id);
                throw new NotFoundException("Subject not found.");
            }

            string imagePath = null;

            if (updateSubjectDto.ImageUrl?.Length > 0)
            {
                _logger.LogDebug("Updating image for subject ID: {SubjectId}", updateSubjectDto.Id);

                
                imagePath = await _fileService.UploadImageAsync(updateSubjectDto.ImageUrl, "Subjects");

                
                if (!string.IsNullOrEmpty(existingSubject.ImageUrl))
                {
                    _fileService.DeleteImage(existingSubject.ImageUrl, "Subjects");
                    _logger.LogDebug("Deleted old image: {OldImagePath}", existingSubject.ImageUrl);
                }

                _logger.LogDebug("New image uploaded: {ImagePath}", imagePath);
            }

            _mapper.Map(updateSubjectDto, existingSubject);

            if (!string.IsNullOrEmpty(imagePath))
            {
                existingSubject.ImageUrl = imagePath;
            }

            existingSubject.TenantId = tenantId;

            await _unitOfWork.SaveChangesAsync();

            var subjectDto = _mapper.Map<ReadSubjectDto>(existingSubject);

            _logger.LogInformation("Successfully updated subject with ID: {SubjectId}", updateSubjectDto.Id);

            return new ApiResponse<ReadSubjectDto>(subjectDto)
            {
                Success = true,
                StatusCode = 200,
                Message = "Subject updated successfully."
            };
        }
        public async Task<ApiResponse<bool>> DeleteSubject(string id)
        {
            var tenantId = GetTenantId();
            if (string.IsNullOrEmpty(tenantId))
                throw new UnauthorizedException("Tenant is missing.");

            _logger.LogInformation("Deleting subject with ID: {SubjectId}, TenantId: {TenantId}", id, tenantId);

            var spec = new SubjectsSpecification(id, tenantId);

            var subject = await _unitOfWork.Repository<Subject, string>()
                .GetByIdWithSpecAsync(spec);

            if (subject == null)
            {
                _logger.LogWarning("Subject not found for deletion with ID: {SubjectId}", id);
                throw new NotFoundException($"Subject with ID {id} not found.");
            }

            if (!string.IsNullOrEmpty(subject.ImageUrl))
            {
                try
                {
                    _fileService.DeleteImage(subject.ImageUrl, "Subjects");
                    _logger.LogDebug("Deleted Subject image: {ImagePath}", subject.ImageUrl);
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "Failed to delete image for Subject ID: {SubjectId}", id);
                }
            }

            _unitOfWork.Repository<Subject, string>().Delete(subject);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation("Successfully deleted Subject with ID: {SubjectId}", id);

            return new ApiResponse<bool>(true)
            {
                Success = true,
                StatusCode = 200,
                Message = "Subject deleted successfully."
            };
        }

       
    }
}
