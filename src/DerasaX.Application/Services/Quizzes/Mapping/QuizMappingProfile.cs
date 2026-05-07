using AutoMapper;
using DerasaX.Application.Dto.QuizDto;
using DerasaX.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Application.Services.Quizzes.Mapping
{
    public class QuizMappingProfile:Profile
    {
        public QuizMappingProfile()
        {
            CreateMap<GetQuizDto, Quiz>().ReverseMap();
            CreateMap<AddQuizDto, Quiz>();
        }
    }
}
