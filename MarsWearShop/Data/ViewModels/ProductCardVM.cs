using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.ViewModels
{
    public class ProductCardVM
    {
        public int Id, FullPrice, CurrPrice, DiscountProcent;
        public byte[] TitleImg, AdditionalImg;
        public string Name;
        public string[] Sizes;

        public bool IsDiscount => DiscountProcent > 0;
    }
}
