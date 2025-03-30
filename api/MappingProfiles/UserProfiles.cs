using api.DTOs;
using api.Models;
using AutoMapper;

namespace api.MappingProfiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
