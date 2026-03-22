using DerasaX.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Models
{
    public class SecurityQuestion :BaseEntity<int>
    {
        public string Question { get; set; }
    }
}
