using System.Collections.Generic;

namespace Decors.Domain.Entities
{
    public class Permission: EntityBase
    {
        public virtual ICollection<RolePermission> Roles { get; set; }
    }
}
