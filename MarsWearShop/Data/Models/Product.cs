using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public int FullPrice { get; set; }
        public int DiscountProcent { get; set; }
        public int CurrPrice { get; set; }
        public bool ShowOnMainPage { get; set; }
        public DateTime Date { get; set; }
        public bool Hide { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public int? ProductGroupId { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public ICollection<Img> Imgs { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            Imgs = new List<Img>();
            ProductSizes = new List<ProductSize>();
        }
    }
}
