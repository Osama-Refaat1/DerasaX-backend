using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Dto.LessonDto
{
    public class AddLessonDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string UnitId { get; set; }
    }
}
