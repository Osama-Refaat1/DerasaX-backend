using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Dto.SubjectDto
{
    public class AddSubjectDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public IFormFile? ImageUrl { get; set; }
        public string GradeId { get; set; }
    }
}
