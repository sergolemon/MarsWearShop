using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class Img
    {
        public int Id { get; set; }
        public byte[] File { get; set; }
        public bool TitleImg { get; set; }
        public int ProductId { get; set; }
    }
}
