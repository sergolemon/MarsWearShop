using MarsWearShop.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class OrderData : BaseOrderData
    {
        public int OrderId { get; set; }
        public string Comment { get; set; }
    }
}
