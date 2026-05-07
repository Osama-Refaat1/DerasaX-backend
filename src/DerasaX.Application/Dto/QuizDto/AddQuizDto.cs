using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Dto.QuizDto
{
    public class AddQuizDto
    {
        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Core;
        public int TimeLimitMinutes { get; set; } = 30;
        public QuizType Type { get; set; } = QuizType.Lesson;
        public string? LessonId { get; set; }
        public string? SubjectId { get; set; }
    }
}
