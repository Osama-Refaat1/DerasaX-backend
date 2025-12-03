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
    public class Question :BaseEntity
    {
        public string Text { get; set; } = null!;
        public QuestionType Type { get; set; }
        public int Points { get; set; } = 1;
        [ForeignKey("Quiz")]
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<QuestionOption> Options { get; set; } = new HashSet<QuestionOption>();
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; } = new HashSet<SubmissionAnswer>();
    }
}
