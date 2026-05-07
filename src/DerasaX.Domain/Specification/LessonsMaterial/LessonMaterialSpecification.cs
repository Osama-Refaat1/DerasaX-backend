using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Specification.LessonsMaterial
{
    public class LessonMaterialSpecification :BaseSpecification<LessonMaterial,string>
    {
        public LessonMaterialSpecification(string id, string tenantId)
         : base(x => x.Id == id && x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public LessonMaterialSpecification(string tenantId)
            : base(x => x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public LessonMaterialSpecification(string LessonId, string tenantId, bool ByLesson)
            : base(x => x.LessonId == LessonId && x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(x => x.Lesson);
        }
    }
}
