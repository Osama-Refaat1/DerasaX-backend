using AutoMapper;
using DerasaX.Application.Dto.LessonDto;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Lessons.Mapping
{
    public class LessonMappingProfile :Profile
    {
        public LessonMappingProfile()
        {
            CreateMap<AddLessonDto, Lesson>();
            CreateMap<GetLessonDto, Lesson>().ReverseMap();
        }
    }
}
