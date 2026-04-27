using DerasaX.Application.Dto.UnitDto;
using DerasaX.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.Unit
{
    public interface IUnitServices
    {
        Task<ApiResponse<IEnumerable<ReadUnitDto>>> GetUnitBySubjectIdAsync(string subjectId);
        Task<ApiResponse<ReadUnitDto>> AddUnitAsync(AddUnitDto addUnitDto);
        Task<ApiResponse<ReadUnitDto>> UpdateUnitAsync(UpdateUnitDto updateUnitDto);
        Task<ApiResponse<bool>> DeleteUnit(string id);
    }
}
