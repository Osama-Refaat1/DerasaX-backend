using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Grade :BaseEntity
    {
        public GradeType gradeType { get; set; }
        public ICollection<Student> students { get; set; } = new HashSet<Student>();
        public ICollection<GradeSubject> GradeSubjects { get; set; } = new HashSet<GradeSubject>();
    }
}
