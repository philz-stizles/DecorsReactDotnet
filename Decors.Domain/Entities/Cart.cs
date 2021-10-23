using System.Collections.Generic;

namespace Decors.Domain.Entities
{
    public class Cart: EntityBase
    {
        public decimal TotalAmount { get; set; }
        public decimal TotalAfterDiscount { get; set; }
        public virtual ICollection<CartItem> Items { get; set; }
    }
}
