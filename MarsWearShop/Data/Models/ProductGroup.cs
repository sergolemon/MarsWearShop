using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class ProductGroup
    {
        public int Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public ProductGroup()
        {
            Products = new List<Product>();
        }
    }
}
