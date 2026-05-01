using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.SubjectDto;
using DerasaX.Domain.Common;
using DerasaX.Domain.Specification.Subjects;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.Subject
{
    public interface ISubjectServices
    {
        Task<PaginationResponse<IEnumerable<ReadSubjectDto>>> GetSubjectsAsync(SubjectsParameters parameters);
        Task<ApiResponse<ReadSubjectDto>> GetSubjectByIdAsync(string id);
        Task<ApiResponse<IEnumerable<ReadSubjectDto>>> GetSubjectsByGradeIdAsync(string gradeId);
        Task<ApiResponse<ReadSubjectDto>> AddSubjectAsync(AddSubjectDto addSubjectDto);
        Task<ApiResponse<ReadSubjectDto>> UpdateSubjectAsync(UpdateSubjectDto updateSubjectDto);
        Task<ApiResponse<bool>> DeleteSubject(string id);

    }
}
