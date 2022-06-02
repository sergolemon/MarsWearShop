using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class Cart
    {
        public string Id { get; set; }
        public DateTime LastUseDate { get; set; }
        public int? UserId { get; set; }
        public ICollection<CartItem> Items { get; set; }
        public Cart()
        {
            Items = new List<CartItem>();
        }
    }
}
