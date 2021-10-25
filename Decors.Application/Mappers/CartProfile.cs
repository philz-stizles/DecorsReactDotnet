using AutoMapper;
using Decors.Application.Models.Dtos;
using Decors.Application.Services.Cart;
using Decors.Domain.Entities;

namespace Decors.Application.Mappers
{
    public class CartProfile: Profile
    {
        public CartProfile()
        {
            CreateMap<SaveCart.Command, Cart>();
            CreateMap<Cart, CartDto>();
            CreateMap<CartItemDto, CartItem>();
        }
    }
}
