using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Dto.UnitDto
{
    public class AddUnitDto
    {
        public string Title { get; set; }
        public string SubjectId { get; set; }
        
    }
}
