using DerasaX.Application.Dto.SubjectDto;
using DerasaX.Application.Services.Image.FoldersName;
using DerasaX.Application.Services.Image.GenericResolver;
using DerasaX.Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Subjects.Mapping
{
    public class SubjectPictureUrlResolver : GenericPictureUrlResolver<Subject, ReadSubjectDto>
    {
        public SubjectPictureUrlResolver(IHttpContextAccessor httpContextAccessor)
           : base(httpContextAccessor, FoldersNames.Subjects)
        {
        }
    }
}
