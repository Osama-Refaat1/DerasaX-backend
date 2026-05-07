using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Dto.LessonMaterialDto
{
    public class GetLessonMaterialDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public AttachmentType Type { get; set; }
        public string LessonId { get; set; }
    }
}
