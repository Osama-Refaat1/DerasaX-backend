using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Lesson :BaseEntity<string>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        [ForeignKey("Unit")]
        public string UnitId { get; set; }
        public Unit Unit { get; set; }
        public ICollection<LessonMaterial> materials { get; set; } = new HashSet<LessonMaterial>();
        public ICollection<Quiz> Quizzes { get; set; } = new HashSet<Quiz>();
        public ICollection<StudentLessonProgress> studentLessonProgresses { get; set; } = new HashSet<StudentLessonProgress>();
    }
}


