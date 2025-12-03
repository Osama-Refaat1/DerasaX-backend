using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class GradeSubject :BaseEntity
    {
        [ForeignKey("Grade")]
        public Guid GradeId { get; set; }
        public Grade Grade { get; set; }
        [ForeignKey("Subject")]
        public Guid SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
