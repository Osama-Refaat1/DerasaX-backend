using AutoMapper;
using DerasaX.Application.Dto.UnitDto;
using DerasaX.Application.Services.Subjects.Mapping;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Units.Mapping
{
    public class UnitMappingProfile : Profile
    {
        public UnitMappingProfile()
        {
            CreateMap<AddUnitDto, Unit>();
            CreateMap<Unit, ReadUnitDto>().ReverseMap();
            CreateMap<UpdateUnitDto, Unit>().ReverseMap();
        }
    }
}
