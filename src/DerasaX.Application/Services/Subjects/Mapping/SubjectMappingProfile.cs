using AutoMapper;
using DerasaX.Application.Dto.SubjectDto;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Subjects.Mapping
{
    public class SubjectMappingProfile :Profile
    {
        public SubjectMappingProfile()
        {
            CreateMap<AddSubjectDto,Subject >().ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
            CreateMap<Subject, ReadSubjectDto>().ForMember(dest => dest.ImageUrl, opt => opt.MapFrom<SubjectPictureUrlResolver>()).ReverseMap();
            CreateMap<UpdateSubjectDto, Subject>().ReverseMap().ForMember(dest => dest.ImageUrl, opt => opt.Ignore());
        }
    }
}
