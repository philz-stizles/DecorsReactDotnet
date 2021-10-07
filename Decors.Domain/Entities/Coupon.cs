namespace Decors.Domain.Entities
{
    public class Coupon: EntityBase
    {
        public string Code { get; set; }
        public int Discount { get; set; }
    }
}
