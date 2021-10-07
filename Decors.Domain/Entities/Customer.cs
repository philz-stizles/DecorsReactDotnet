namespace Decors.Domain.Entities
{
    public class Customer: EntityBase
    {
        public virtual User User { get; set; }
    }
}
