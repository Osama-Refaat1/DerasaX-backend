using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Lesson :BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
        public ICollection<LessonAttachment> Attachments { get; set; } = new HashSet<LessonAttachment>();
        public ICollection<Quiz> Quizzes { get; set; } = new HashSet<Quiz>();
        public ICollection<StudentLessonProgress> studentLessonProgresses { get; set; } = new HashSet<StudentLessonProgress>();
    }
}
