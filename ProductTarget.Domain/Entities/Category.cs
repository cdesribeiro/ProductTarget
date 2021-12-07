using System.Collections.Generic;

namespace Management.Domain.Entities
{
    public class Category : BaseEntity<long>
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
