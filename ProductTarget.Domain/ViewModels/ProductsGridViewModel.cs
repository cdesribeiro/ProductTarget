using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Domain.ViewModels
{
    public class ProductsGridViewModel
    {
        public string search { get; set; }
        public string sort { get; set; }
        public string order { get; set; }
        public int offset { get; set; }
        public int limit { get; set; }
    }
}
