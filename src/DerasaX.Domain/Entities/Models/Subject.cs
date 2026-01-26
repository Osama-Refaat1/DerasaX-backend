using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Subject :BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<GradeSubject> GradeSubjects { get; set; } = new HashSet<GradeSubject>();
        public ICollection<Unit> Units { get; set; } = new HashSet<Unit>();
    }
}
