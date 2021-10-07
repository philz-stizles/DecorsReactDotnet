using AutoMapper;
using Decors.Application.Models;
using Decors.Application.Services.Auth;
using Decors.Domain.Entities;

namespace Decors.Application.Mappers
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterVendor.Command, User>();
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
