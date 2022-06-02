using MarsWearShop.Data.Models;
using MarsWearShop.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Classes
{
    public static class QueryableExtensions
    {
        public static IQueryable<Product> CurrentProducts(this IQueryable<Product> products)
        {
            return products.Where(x => !x.Hide && x.ProductSizes.Any(y => y.Count > 0));
        }

        public static IQueryable<Category> CurrentCategories(this IQueryable<Category> categories)
        {
            return categories.Where(x => x.ProductCategories.Any(y => y.Product.ProductSizes.Any(z => z.Count > 0) && !y.Product.Hide));
        }

        public static IQueryable<CategoryVM> SelectCategoryVM(this IQueryable<Category> categories)
        {
            return categories.Select(x => new CategoryVM { 
                Name = x.Name,
                Link = x.Link
            });
        }

        public static IQueryable<ProductCardVM> SelectProductCardVM(this IQueryable<Product> products)
        {
            return products.Select(x => new ProductCardVM
            { 
                Id = x.Id,
                Name = x.Name,
                TitleImg = x.Imgs.Where(x => x.TitleImg).OrderBy(x => x.Id).First().File,
                AdditionalImg = x.Imgs.Where(x => x.TitleImg).OrderBy(x => x.Id).Last().File,
                Sizes = x.ProductSizes.Where(y => y.Count > 0).Select(y => y.Size.Name).ToArray(),
                FullPrice = x.FullPrice,
                DiscountProcent = x.DiscountProcent,
                CurrPrice = x.CurrPrice
            });
        }

        public static IQueryable<CartItemVM> SelectCartItemVM(this IQueryable<CartItem> products)
        {
            return products.Select(x => new CartItemVM
            {
                Id = x.Id,
                Img = x.Product.Imgs.First(x => x.TitleImg).File,
                ProductId = x.ProductId,
                Count = x.Count,
                MaxCount = x.Product.ProductSizes.Single(y => y.Size.Name == x.Size).Count,
                Name = x.Product.Name,
                Size = x.Size,
                Price = x.Product.CurrPrice
            });
        }
    }
}
