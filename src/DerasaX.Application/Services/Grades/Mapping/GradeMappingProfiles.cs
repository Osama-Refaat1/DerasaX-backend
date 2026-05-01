using AutoMapper;
using DerasaX.Application.Dto.GradeDto;
using DerasaX.Application.Dto.LessonDto;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Grades.Mapping
{
    public class GradeMappingProfiles :Profile
    {
        public GradeMappingProfiles()
        {
            CreateMap<AddGradeDto, Grade>();
            CreateMap<GetGradeDto, Grade>().ReverseMap();
        }
    }
}
