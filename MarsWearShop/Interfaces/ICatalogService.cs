using MarsWearShop.Data.Models;
using MarsWearShop.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Interfaces
{
    public interface ICatalogService
    {
        Task<IEnumerable<ProductCardVM>> GetProductsOnMainPage();
        Task<IEnumerable<CategoryVM>> GetMainCategories();
        Task<IEnumerable<ProductCardVM>> GetProducts(string _categories, int index = 0);
        Task<Product> GetProduct(int id);
        Task<IEnumerable<CategoryVM>> GetCategories(string _categories);
        Task<IEnumerable<ProductCardVM>> GetProductsOnDiscountPage(int index = 0);
    }
}
