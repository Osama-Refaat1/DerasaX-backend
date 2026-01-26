using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Abstractions
{
    public interface ITenantService
    {
        public string? GetDatabaseProvider();
        public string? GetConnectionString();
        public Tenant? GetCurrentTenant();
    }
}
