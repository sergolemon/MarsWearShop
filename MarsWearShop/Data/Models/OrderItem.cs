using MarsWearShop.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public byte[] Img { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int Count { get; set; }
        public int OrderId { get; set; }
        public int Price { get; set; }
    }
}
