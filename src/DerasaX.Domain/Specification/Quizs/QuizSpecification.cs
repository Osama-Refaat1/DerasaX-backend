using DerasaX.Domain.Entities.Models;
using DerasaX.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Specification.Quizs
{
    public class QuizSpecification:BaseSpecification <Quiz,string>
    {
        public QuizSpecification(string id, string tenantId)
         : base(x => x.Id == id && x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public QuizSpecification(string tenantId)
            : base(x => x.TenantId == tenantId)
        {
            ApplyInclude();
        }

        public QuizSpecification(string referenceId, string tenantId, QuizType type)
     : base(BuildCriteria(referenceId, tenantId, type))
        {
            ApplyInclude();
        }

        private static Expression<Func<Quiz, bool>> BuildCriteria(string referenceId, string tenantId, QuizType type)
        {
            return type switch
            {
                QuizType.Lesson =>
                    x => x.LessonId == referenceId && x.TenantId == tenantId,

                QuizType.Final =>
                    x => x.SubjectId == referenceId && x.TenantId == tenantId,

                QuizType.Practice =>
                    x => x.TenantId == tenantId,

                _ =>
                    x => x.TenantId == tenantId
            };
        }
        private void ApplyInclude()
        {
            AddInclude(x => x.Questions);
            AddInclude(x => x.QuizSubmissions);
        }
    }
}
