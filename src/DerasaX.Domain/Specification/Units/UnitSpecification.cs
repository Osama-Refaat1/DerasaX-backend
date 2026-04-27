using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Specification.Units
{
    public class UnitSpecification : BaseSpecification<Unit, string>
    {
        public UnitSpecification(string id, string tenantId)
         : base(x => x.Id == id && x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public UnitSpecification(string tenantId)
            : base(x => x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public UnitSpecification(string subjectId, string tenantId,bool BySubject)
            : base(x => x.SubjectId == subjectId && x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(x => x.Lessons);
        }

    }
}
