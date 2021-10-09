using AutoMapper;
using Decors.Application.Models;
using Decors.Application.Services.Vendors;
using Decors.Domain.Entities;

namespace Decors.Application.Mappers
{
    public class VendorProfile : Profile
    {
        public VendorProfile()
        {
            CreateMap<CreateProduct.Command, Product> ()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
