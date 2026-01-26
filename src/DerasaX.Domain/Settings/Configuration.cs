using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Settings
{
    public class Configuration
    {
        public string DBProvider { get; set; } = null!;
        public string ConnectionString { get; set; } = null!;
    }
}
