using DerasaX.Application.Services.Abstractions;
using DerasaX.Domain.Entities.Models;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace DerasaX.Application.Services
{
    public class TenantService : ITenantService
    {
        private Tenant? _currentTenant;
        public TenantService(IHttpContextAccessor httpContextAccessor)
        {
            var context = httpContextAccessor.HttpContext;
            if (context != null && context.Request.Headers.TryGetValue("tenant", out var tenantId))
            {
                _currentTenant = new Tenant { Id = tenantId };
            }
            else
            {
                throw new Exception("Tenant header is required");
            }
        }
        public Tenant? GetCurrentTenant()
        {
            return _currentTenant;
        }
    }
}
