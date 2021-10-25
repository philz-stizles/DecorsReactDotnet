using System.Collections.Generic;

namespace Decors.Application.Models.Dtos
{
    public class CartDto
    {
        public string Id { get; set; }
        public CartDto(string id)
        {
            Id = id;
        }

        public decimal TotalAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public List<CartItemDto> Items { get; set; } = new List<CartItemDto>();
    }
}
