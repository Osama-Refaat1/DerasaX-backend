using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class QuizGeneration :BaseEntity 
    {
        public string PromptUsed { get; set; }
        public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Quiz")]
        public string QuizId { get; set; }
        public Quiz Quiz { get; set; }

    }
}
