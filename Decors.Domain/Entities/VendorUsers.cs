using System;

namespace Decors.Domain.Entities
{
    public class VendorUsers: EntityBase
    {
        public int VendorId { get; set; }
        public virtual Vendor Vendor { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
