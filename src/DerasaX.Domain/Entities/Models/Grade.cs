using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Grade :BaseEntity
    {
        public string Name { get; set; }
        [ForeignKey("Curriculums")]
        public Guid CurriculumId { get; set; }
        public Curriculums Curriculums { get; set; }
        public ICollection<ApplicationUser> Users { get; set; } = new HashSet<ApplicationUser>();
        public ICollection<GradeSubject> GradeSubjects { get; set; } = new HashSet<GradeSubject>();
    }
}
