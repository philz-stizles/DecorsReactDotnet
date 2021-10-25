namespace Decors.Domain.Entities
{
    public class OrderItem: EntityBase
    {
        public ProductItemOrdered ItemOrdered { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
