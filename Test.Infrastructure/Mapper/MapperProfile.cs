using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Application.Features.TaskJson.DTO;
using Test.Infrastructure.DataModels;

namespace Test.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<JsonTaskDTO, JsonTask>().ReverseMap();
        }
    }
}
