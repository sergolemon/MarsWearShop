using MarsWearShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.ViewModels
{
    public class CatalogVM
    {
        public IEnumerable<ProductCardVM> Products;
        public IEnumerable<CategoryVM> Categories;
    }
}
