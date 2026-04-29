using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.UnitDto;
using DerasaX.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.Lesson
{
    public interface ILessonServices
    {
        Task<ApiResponse<IEnumerable<GetLessonDto>>> GetLessonByUnitIdAsync(string unitId);
        Task<ApiResponse<GetLessonDto>> AddLessonAsync(AddLessonDto addLessonDto);
        Task<ApiResponse<GetLessonDto>> UpdateLessonAsync(GetLessonDto getLessonDto);
        Task<ApiResponse<bool>> DeleteLesson(string id);
    }
}
