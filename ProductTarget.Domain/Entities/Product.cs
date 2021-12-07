using System;

namespace Management.Domain.Entities
{
    public class Product : BaseEntity<long>
    {
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
        public bool Active { get; set; }
        public long? CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
