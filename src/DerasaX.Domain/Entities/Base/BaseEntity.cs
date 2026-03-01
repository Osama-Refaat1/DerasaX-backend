using DerasaX.Application.Services.Abstractions;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Entities.Base
{
    public class BaseEntity<Tkey>: IMustHaveTenant
    {
        public Tkey Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string TenantId { get; set; } 
    }
}
