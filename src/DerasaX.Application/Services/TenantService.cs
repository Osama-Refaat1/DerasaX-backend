using DerasaX.Application.Services.Abstractions;
using DerasaX.Domain.Entities.Models;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DerasaX.Domain.Settings;
using Microsoft.Extensions.Options;

namespace DerasaX.Application.Services
{
    public class TenantService : ITenantService
    {
        private readonly TenantSettings _tenantSettings;
        private HttpContext? _HttpContext;
        private Tenant? _currentTenant;
        public TenantService(IHttpContextAccessor httpContextAccessor,IOptions<TenantSettings> tenantSettings )
        {
            _HttpContext=httpContextAccessor.HttpContext;
            _tenantSettings=tenantSettings.Value;
            if(_HttpContext is not null)
            {
                if (_HttpContext.Request.Headers.TryGetValue("tenant", out var tenantId))
                {
                    SetCurrentTenant(tenantId!);
                }
                else
                {
                    throw new Exception("No tenant provided");
                }
            }
        }
        public string? GetConnectionString()
        {
            var currentConnectionString = _currentTenant is null
                ? _tenantSettings.Defaults.ConnectionString
                :_currentTenant.ConnectionString;
            return currentConnectionString;
        }
        public Tenant? GetCurrentTenant()
        {
            return _currentTenant;
        }
        public string? GetDatabaseProvider()
        {
            return _tenantSettings.Defaults.DBProvider;
        }
        private void SetCurrentTenant(string tenantId)
        {
            _currentTenant= _tenantSettings.Tenants.FirstOrDefault(t => t.Id==tenantId);
            if (_currentTenant is null)
            {
                throw new Exception("Invalid Tenant Id");
            }
            if (string.IsNullOrEmpty(_currentTenant.ConnectionString))
            {
                _currentTenant.ConnectionString=_tenantSettings.Defaults.ConnectionString;
            }
        }
    }
}
