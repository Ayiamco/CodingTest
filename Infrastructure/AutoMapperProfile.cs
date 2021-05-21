using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Coding_Test.Dtos;
using Coding_Test.Entities;

namespace Coding_Test.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<RegisterDto, ApplicationUser>()
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
            //    .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now));
        }
        
    }
}
