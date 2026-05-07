using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Quiz:BaseEntity<string>
    {
        public DifficultyLevel Difficulty { get; set; } = DifficultyLevel.Core;
        public DateTime? DueDate { get; set; }
        public int TimeLimitMinutes { get; set; } = 30;
        public QuizType Type { get; set; } = QuizType.Lesson;

        public string? LessonId { get; set; }
        public Lesson? Lesson { get; set; }

        public string? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public ICollection<Question> Questions { get; set; } = new HashSet<Question>();
        public ICollection<QuizSubmission> QuizSubmissions { get; set; } = new HashSet<QuizSubmission>();
    }
}
