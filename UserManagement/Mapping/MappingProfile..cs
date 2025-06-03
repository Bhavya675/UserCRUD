using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.DTO;
using AutoMapper;
using UserManagement.Entities;
using UserManagement.Models.DTO.Request;
// using UserManagement.Models;

namespace UserManagement.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
        }
    }
}