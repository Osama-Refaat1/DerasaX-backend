using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Specification.Subjects
{
    public class SubjectForCountingSpecification : BaseSpecification<Subject, string>
    {
        public SubjectForCountingSpecification(SubjectsParameters parameters, string tenantId)
         : base(x =>
             x.TenantId == tenantId &&
             (string.IsNullOrEmpty(parameters.Search) ||
              x.Name.ToLower().Contains(parameters.Search.ToLower())))
        {
        }
    }
}
