using AutoMapper;
using Decors.Application.Models;
using Decors.Domain.Entities;

namespace Decors.Application.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
