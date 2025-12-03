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
    public class QuizSubmission :BaseEntity
    {
        public int Score { get; set; }          
        public int TotalScore { get; set; }      
        public double Percentage => TotalScore > 0 ? (double)Score / TotalScore * 100 : 0;
        public string? TeacherFeedback { get; set; }
        public SubmissionStatus submissionStatus { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        [ForeignKey("Quiz")]
        public Guid QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; } = new HashSet<SubmissionAnswer>();

    }
}
