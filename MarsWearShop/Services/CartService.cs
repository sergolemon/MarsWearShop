using MarsWearShop.Classes;
using MarsWearShop.Data;
using MarsWearShop.Data.Models;
using MarsWearShop.Data.ViewModels;
using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Services
{
    public class CartService : ICartService
    {
        readonly string Id;
        readonly AppDbContext db;
        public CartService(AppDbContext context, IHttpContextAccessor http)
        {
            db = context;
            var HttpContext = http.HttpContext;

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var userCartId = db.Users.Where(x => x.Login == HttpContext.User.Identity.Name).Select(x => new { UserId = x.Id, CartId = x.Cart.Id }).Single();

                if (userCartId.CartId == null)
                {
                    Id = Guid.NewGuid().ToString();
                    db.Carts.Add(new Cart { Id = Id, LastUseDate = DateTime.Now, UserId = userCartId.UserId });
                    db.SaveChanges();
                }
                else Id = userCartId.CartId;
            }
            else
            {
                Id = HttpContext.Request.Cookies["CartId"];

                if (Id == null)
                {
                    Id = Guid.NewGuid().ToString();
                    db.Carts.Add(new Cart { Id = Id, LastUseDate = DateTime.Now });
                }
                else
                {
                    Cart cart = db.Carts.SingleOrDefault(x => x.Id == Id);

                    if (cart == null)
                    {
                        db.Carts.Add(new Cart { Id = Id, LastUseDate = DateTime.Now });
                    }
                    else
                    {
                        cart.LastUseDate = DateTime.Now;
                    }
                }

                db.SaveChanges();
                HttpContext.Response.Cookies.Append("CartId", Id, new CookieOptions { Expires = DateTime.Now.AddDays(30), HttpOnly = true });
            }
        }

        public async Task<int> GetItemsCount()
        {
            return await db.CartItems.Where(x => x.CartId == Id).CountAsync();
        }

        public async Task<IEnumerable<CartItemVM>> GetCart()
        {
            return await db.CartItems.Where(x => x.CartId == Id).SelectCartItemVM().ToListAsync();
        }

        public async Task ClearCart()
        {
            IEnumerable<CartItem> items = await db.CartItems.Where(x => x.CartId == Id).ToListAsync();

            db.RemoveRange(items);
            await db.SaveChangesAsync();
        }

        public async Task<int> AddItem(int productId, string size)
        {
            int count = 0;

            var ci = await db.CartItems.Where(x => x.CartId == Id && x.ProductId == productId && x.Size == size)
                .Select(x => new { 
                    Id = x.Id,
                    Count = x.Count,
                    MaxCount = x.Product.ProductSizes.Single(y => y.Size.Name == size).Count 
                })
                .SingleOrDefaultAsync();

            if (ci != null)
            {
                count = ci.Count;

                if (ci.Count + 1 <= ci.MaxCount)
                {
                    db.CartItems.SingleOrDefault(x => x.Id == ci.Id).Count++;
                    await db.SaveChangesAsync();
                    count++;
                }
            }
            else
            {
                if (await db.Products.AnyAsync(x => x.Id == productId && !x.Hide && x.ProductSizes.Any(y => y.Size.Name == size && y.Count > 0)))
                {
                    await db.CartItems.AddAsync(new CartItem { CartId = Id, Count = 1, Size = size, ProductId = productId });
                    await db.SaveChangesAsync();
                    count = 1;
                }
            }

            return count;
        }

        public async Task DeleteItem(int id)
        {
            CartItem item = await db.CartItems.SingleAsync(x => x.CartId == Id && x.Id == id);

            db.CartItems.Remove(item);
            await db.SaveChangesAsync();
        }

        public async Task<int> PlusItem(int id)
        {
            var ci = await db.CartItems.Where(x => x.CartId == Id && x.Id == id)
                .Select(x => new {
                    Id = x.Id,
                    Count = x.Count,
                    MaxCount = x.Product.ProductSizes.Single(y => y.Size.Name == x.Size).Count
                })
                .SingleAsync();

            int count = ci.Count;

            if (ci.Count + 1 <= ci.MaxCount)
            {
                db.CartItems.Single(x => x.Id == ci.Id).Count++;
                await db.SaveChangesAsync();

                count++;
            }

            return count;
        }

        public async Task<int> MinusItem(int id)
        {
            var ci = await db.CartItems.Where(x => x.CartId == Id && x.Id == id)
                .Select(x => new {
                    Id = x.Id,
                    Count = x.Count,
                })
                .SingleAsync();

            int count = ci.Count;

            if (ci.Count - 1 >= 1)
            {
                db.CartItems.Single(x => x.Id == ci.Id).Count--;
                await db.SaveChangesAsync();

                count--;
            }

            return count;
        }

        public async Task<CartItemVM> GetLastItem()
        {
            return await db.CartItems.Where(x => x.CartId == Id).OrderBy(x => x.Id).SelectCartItemVM().LastAsync();
        }
    }
}
