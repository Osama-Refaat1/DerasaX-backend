using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.LessonMaterialDto;
using DerasaX.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.LessonMaterial
{
    public interface ILessonMaterialServicess
    {
        Task<ApiResponse<IEnumerable<GetLessonMaterialDto>>> GetMaterialByLessonIdAsync(string lessonId);
        Task<ApiResponse<GetLessonMaterialDto>> AddMaterialAsync(AddLessonMaterialDto addLessonMaterialDto);
        Task<ApiResponse<GetLessonMaterialDto>> UpdateMaterialAsync(GetLessonMaterialDto getLessonMaterialDto);
        Task<ApiResponse<bool>> DeleteMaterial(string id);
    }
}
