using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class Subject :BaseEntity<string>,IHasImageUrl
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        [ForeignKey("grade")]
        public string GradeId { get; set; }
        public Grade grade { get; set; }
        public ICollection<Unit> Units { get; set; } = new HashSet<Unit>();
    }
}
