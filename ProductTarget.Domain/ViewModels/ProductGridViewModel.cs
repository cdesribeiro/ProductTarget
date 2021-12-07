using System;
using System.Collections.Generic;
using System.Text;

namespace ProductTarget.Domain.ViewModels
{
    public class ProductGridViewModel
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string RegistrationDate { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
        public decimal TotalValue { get; set; }
    }
}
