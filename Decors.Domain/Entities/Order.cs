using Decors.Domain.Enums;

namespace Decors.Domain.Entities
{
    public class Order: EntityBase
    {
        public OrderStatus Status { get; set; }
    }
}
