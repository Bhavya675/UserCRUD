using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalAPI.DTO;
using AutoMapper;
using MinimalAPI.Entities;
using MinimalAPI.Models.DTO.Request;
// using MinimalAPI.Models;

namespace MinimalAPI.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}