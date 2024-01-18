using AutoMapper;
using SIS.Models.DTOs.Users;
using SIS.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIS.Website.ConfigurationAutoMapper
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserAddDto>().ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserId));
                cfg.CreateMap<User, UserEditDto>().ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserId));
                cfg.CreateMap<User, UserResultDto>().ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.UserId));

            });


        }
    }
}
