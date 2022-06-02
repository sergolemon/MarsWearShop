using MarsWearShop.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class UserOrderData : BaseOrderData
    {
        public int UserId { get; set; }
    }
}
