using System.Collections.Generic;

namespace Decors.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}