using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int? CategoryId { get; set; }
        public byte[] Img { get; set; }
        public ICollection<Category> Subcategories { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public Category()
        {
            Subcategories = new List<Category>();
            ProductCategories = new List<ProductCategory>();
        }
    }
}
