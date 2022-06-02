using MarsWearShop.Classes;
using MarsWearShop.Data;
using MarsWearShop.Data.Models;
using MarsWearShop.Data.ViewModels;
using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Services
{
    public class CatalogService : ICatalogService
    {
        private static readonly int Limit = 9;
        readonly AppDbContext db;
        public CatalogService(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            db = context;
        }

        public async Task<IEnumerable<ProductCardVM>> GetProductsOnMainPage()
        {
            return await db.Products.CurrentProducts().Where(x => x.ShowOnMainPage).OrderByDescending(x => x.Id).Take(Limit).SelectProductCardVM().ToListAsync();
        }

        public async Task<IEnumerable<ProductCardVM>> GetProductsOnDiscountPage(int index = 0)
        {
            return await db.Products.CurrentProducts().Where(x => x.DiscountProcent > 0).OrderByDescending(x => x.Id).Skip(index * Limit).Take(Limit).SelectProductCardVM().ToListAsync();
        }

        public async Task<IEnumerable<CategoryVM>> GetMainCategories()
        {
            return await db.Categories.Where(x => x.CategoryId == null).CurrentCategories().SelectCategoryVM().ToListAsync();
        }

        public async Task<IEnumerable<ProductCardVM>> GetProducts(string _categories, int index = 0)
        {
            string[] categories = string.IsNullOrEmpty(_categories) ? new string[0] : _categories.Split('/');
            IQueryable<Product> query = null;

            if (categories.Any())
            {
                IQueryable<Category> categoryQuery = db.Categories.Where(x => x.CategoryId == null);

                for (int i = 0; i < categories.Length; i++)
                {
                    string category = categories[i];

                    categoryQuery = categoryQuery.Where(x => x.Link == category);

                    if (i == categories.Length - 1) query = categoryQuery.SelectMany(x => x.ProductCategories).Select(x => x.Product);
                    else categoryQuery = categoryQuery.SelectMany(x => x.Subcategories);
                }
            }
            else
            {
                query = db.Products;
            }
     
            return await query.CurrentProducts().OrderByDescending(x => x.Id).Skip(index * Limit).Take(Limit).SelectProductCardVM().ToListAsync();
        }

        public async Task<IEnumerable<CategoryVM>> GetCategories(string _categories)
        {
            string[] categories = string.IsNullOrEmpty(_categories) ? new string[0] : _categories.Split('/');
            IQueryable<Category> query = db.Categories.Where(x => x.CategoryId == null);

            for (int i = 0; i < categories.Length; i++)
            {
                string currentCategory = categories[i];

                query = query.Where(x => x.Link == currentCategory).SelectMany(x => x.Subcategories);
            }

            query = query.CurrentCategories();

            return await query.SelectCategoryVM().ToListAsync();
        }

        public async Task<Product> GetProduct(int id)
        {
            return await db.Products.CurrentProducts().Where(x => x.Id == id).Select(x => new Product { 
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).SingleOrDefaultAsync();
        }
    }
}
