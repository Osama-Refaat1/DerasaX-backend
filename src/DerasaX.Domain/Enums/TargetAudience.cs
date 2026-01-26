using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Enums
{
    [Flags]
    public enum TargetAudience
    {
        None = 0,
        Students = 1,
        Parents = 2,
        Teachers = 4,
        All = Students | Parents | Teachers
    }
}
