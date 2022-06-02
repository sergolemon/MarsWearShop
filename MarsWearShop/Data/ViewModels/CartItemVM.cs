using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.ViewModels
{
    public class CartItemVM
    {
        public int Id, ProductId, Price, Count, MaxCount;
        public string Name, Size;
        public byte[] Img;
    }
}
