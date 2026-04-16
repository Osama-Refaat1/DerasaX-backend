using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Exceptions
{
    public class NotFoundException :Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
        public NotFoundException(string Entity, string id) : base(($"{Entity} with ID {id}  not found"))
        {

        }
    }
}
