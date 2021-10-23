using System.Collections.Generic;

namespace Decors.Domain.Entities
{
    public class Vendor: EntityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public virtual ICollection<VendorUsers> Users { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Coupon> Coupons { get; set; }
    }
}
