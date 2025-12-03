using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class StudentLessonProgress:BaseEntity
    {
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedAt { get; set; }
        public int WatchedAttachments { get; set; } = 0;
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public ApplicationUser Student { get; set; }
        [ForeignKey("Lesson")]
        public Guid LessonId { get; set; }
        public Lesson Lesson { get; set; }

    }
}
