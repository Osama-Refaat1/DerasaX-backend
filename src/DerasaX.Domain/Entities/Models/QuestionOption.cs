using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class QuestionOption :BaseEntity<string>
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; } = false;
        [ForeignKey("Question")]
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public ICollection<SubmissionAnswer> SubmissionAnswers { get; set; } = new HashSet<SubmissionAnswer>();
    }
}
