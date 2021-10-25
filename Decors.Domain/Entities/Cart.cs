using System.Collections.Generic;

namespace Decors.Domain.Entities
{
    public class Cart
    {
        public Cart()
        {
        }

        public Cart(string id)
        {
            Id = id;
        }

        public string Id { get; set; } // This will be generated from the client-side
        public decimal TotalAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
