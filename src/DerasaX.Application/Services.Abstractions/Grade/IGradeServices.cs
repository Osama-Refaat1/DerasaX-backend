using DerasaX.Application.Dto.GradeDto;
using DerasaX.Application.Dto.UnitDto;
using DerasaX.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.Grade
{
    public interface IGradeServices
    {
        Task<ApiResponse<IEnumerable<GetGradeDto>>> GetAllGradeAsync();
        Task<ApiResponse<GetGradeDto>> GetGradeByIdAsync(string id);
        Task<ApiResponse<GetGradeDto>> AddGradeAsync(AddGradeDto addGradeDto);
        Task<ApiResponse<GetGradeDto>> UpdateGradeAsync(GetGradeDto getGradeDto); 
        Task<ApiResponse<bool>> DeleteGrade(string id);
    }
}
