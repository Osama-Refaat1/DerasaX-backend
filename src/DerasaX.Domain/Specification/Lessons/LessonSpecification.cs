using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Specification.Lessons
{
    public class LessonSpecification :BaseSpecification<Lesson ,string>
    {
        public LessonSpecification(string id, string tenantId)
         : base(x => x.Id == id && x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public LessonSpecification(string tenantId)
            : base(x => x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public LessonSpecification(string UnitId, string tenantId, bool ByUnit)
            : base(x => x.UnitId == UnitId && x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            AddInclude(x => x.materials);
            AddInclude(x => x.studentLessonProgresses);
            AddInclude(x => x.Quizzes);
        }
    }
}
