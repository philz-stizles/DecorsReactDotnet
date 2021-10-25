using System;

namespace Decors.Domain.Entities
{
    public class Customer: EntityBase
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
