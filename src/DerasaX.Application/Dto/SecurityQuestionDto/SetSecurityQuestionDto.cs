using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Dto.SecurityQuestionDto
{
    public class SetSecurityQuestionDto
    {
        public int SecurityQuestionId { get; set; }
        public string Answer { get; set; } = string.Empty;
    }
}
