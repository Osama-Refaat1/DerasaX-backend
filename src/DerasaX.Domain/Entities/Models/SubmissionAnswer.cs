using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class SubmissionAnswer :BaseEntity
    {
        public bool IsCorrect { get; set; }             
        public int PointsEarned { get; set; } = 0;
        [ForeignKey("Question")]
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        [ForeignKey("QuizSubmission")]
        public Guid QuizSubmissionId { get; set; }
        public QuizSubmission QuizSubmission { get; set; }
        [ForeignKey("SelectedOption")]
        public Guid? SelectedOptionId { get; set; }
        public QuestionOption? SelectedOption { get; set; }

    }
}
