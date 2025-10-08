using AutoMapper;
using UserManagement.Entities;
using UserManagement.Models;

namespace UserManagement.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserResponseDTO>().ReverseMap();
        }
    }
}