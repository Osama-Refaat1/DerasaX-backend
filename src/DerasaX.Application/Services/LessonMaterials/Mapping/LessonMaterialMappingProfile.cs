using AutoMapper;
using DerasaX.Application.Dto.LessonMaterialDto;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.LessonMaterials.Mapping
{
    public class LessonMaterialMappingProfile :Profile
    {
        public LessonMaterialMappingProfile()
        {
            CreateMap<AddLessonMaterialDto, LessonMaterial>();
            CreateMap<GetLessonMaterialDto, LessonMaterial>().ReverseMap();
        }
    }
}
