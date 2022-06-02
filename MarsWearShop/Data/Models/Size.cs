﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public Size()
        {
            ProductSizes = new List<ProductSize>();
        }
    }
}
