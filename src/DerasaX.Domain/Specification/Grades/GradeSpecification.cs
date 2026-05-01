using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Specification.Grades
{
    public class GradeSpecification :BaseSpecification<Grade,string>
    {
        public GradeSpecification(string id, string tenantId)
            : base(x => x.Id == id && x.TenantId == tenantId)
        {
            ApplyInclude();
        }
        public GradeSpecification(string tenantId)
            : base(x => x.TenantId == tenantId)
        {
            ApplyInclude();
        }
        private void ApplyInclude()
        {
            AddInclude(x => x.subjects);
            AddInclude(x => x.students);
        }
    }
}
