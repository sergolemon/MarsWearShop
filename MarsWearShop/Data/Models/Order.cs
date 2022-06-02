using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? OrderStatusId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int? UserId { get; set; }
        public OrderData OrderData { get; set; }
        public ICollection<OrderItem> Items { get; set; }
        public int TotalPrice { get; set; }
        public Order()
        {
            Items = new List<OrderItem>();
        }
    }
}
