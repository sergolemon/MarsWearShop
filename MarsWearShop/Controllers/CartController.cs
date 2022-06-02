using MarsWearShop.Data.ViewModels;
using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Controllers
{
    public class CartController : Controller
    {
        readonly ICartService Cart;

        public CartController(ICartService cart)
        {
            Cart = cart;
        }

        [HttpPost]
        public async Task<int> AddToCartItem(int productId, string size)
        {
            return await Cart.AddItem(productId, size);
        }

        [HttpPost]
        public async Task DeleteItem(int id)
        {
            await Cart.DeleteItem(id);
        }

        [HttpPost]
        public async Task ClearCart()
        {
            await Cart.ClearCart();
        }

        [HttpPost]
        public async Task<int> PlusItem(int id)
        {
            return await Cart.PlusItem(id);
        }

        [HttpPost]
        public async Task<int> MinusItem(int id)
        {
            return await Cart.MinusItem(id);
        }

        [HttpPost]
        public async Task<PartialViewResult> LoadNewItem()
        {
            return PartialView("_CartItem", await Cart.GetLastItem());
        }
    }
}
