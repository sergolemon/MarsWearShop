using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Abstract
{
    public abstract class BaseOrderData
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string FullName { get; set; }
        public string Locality { get; set; }
        public string PostOffice { get; set; }
    }
}
