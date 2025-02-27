using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using users_wf.DTOs;
using users_wf.Models;

namespace users_wf.MapperProfiles
{
    public class MovieMapperProfile : Profile
    {
        public MovieMapperProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
        }
    }
}