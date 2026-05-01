using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Specification.Subjects
{
    public class SubjectsSpecification : BaseSpecification<Subject, string>
    {
        public SubjectsSpecification(SubjectsParameters parameters, string tenantId)
            : base(x =>
            x.TenantId == tenantId &&
            (string.IsNullOrEmpty(parameters.Search) ||
             x.Name.ToLower().Contains(parameters.Search.ToLower())))
        {
            ApplyInclude();
            ApplyPaging(parameters.PageNumber, parameters.PageSize);
        }
        public SubjectsSpecification(string id, string tenantId)
        : base(x => x.Id == id && x.TenantId == tenantId)
        {
            ApplyInclude();
        }
        public SubjectsSpecification(string tenantId)
       : base(x => x.TenantId == tenantId)
        {
            ApplyInclude();
        }
        public SubjectsSpecification(string gradeId, string tenantId, bool byGrade)
         : base(x => x.GradeId == gradeId && x.TenantId == tenantId)
        {
            ApplyInclude();
        }
        private void ApplyInclude()
        {
            AddInclude(x => x.Units);
        }
    }

}
