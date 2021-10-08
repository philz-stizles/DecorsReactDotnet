using AutoMapper;
using Decors.Application.Models;
using Decors.Domain.Entities;

namespace Decors.Application.Mappers
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
