using System.Collections.Generic;

namespace Decors.Domain.Entities
{
    public class Cart: EntityBase
    {
        public virtual ICollection<CartItem> Items { get; set; }
    }
}
