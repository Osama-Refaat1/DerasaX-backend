using DerasaX.Application.Dto.GradeDto;
using DerasaX.Application.Dto.LessonDto;
using DerasaX.Application.Dto.QuizDto;
using DerasaX.Domain.Common;
using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions.Quiz
{
    public interface IQuizServices
    {
        Task<ApiResponse<IEnumerable<GetQuizDto>>> GetAllQuizzesAsync();
        Task<ApiResponse<IEnumerable<GetQuizDto>>> GetQuizzesByTypeAsync(string referenceId , QuizType type);
        Task<ApiResponse<GetQuizDto>> GetQuizByIdAsync(string id);
        Task<ApiResponse<GetQuizDto>> CreateQuizAsync(AddQuizDto addQuizDto);
        Task<ApiResponse<GetQuizDto>> UpdateQuizAsync(GetQuizDto getQuizDto);
        Task<ApiResponse<bool>> DeleteQuizAsync(string id);
    }
}
