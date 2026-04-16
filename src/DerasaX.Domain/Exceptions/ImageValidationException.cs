using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Exceptions
{
    public class ImageValidationException(string message) : Exception(message);
    
  
}
