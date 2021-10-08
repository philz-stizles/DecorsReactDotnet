using AutoMapper;
using Decors.Application.Models;
using Decors.Application.Services.Products;
using Decors.Domain.Entities;

namespace Decors.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProduct.Command, Product> ()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
