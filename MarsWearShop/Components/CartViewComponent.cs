using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Components
{
    public class CartViewComponent : ViewComponent
    {
        readonly ICartService Cart;

        public CartViewComponent(ICartService cart)
        {
            Cart = cart;
        }

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            return View(await Cart.GetCart());
        }
    }
}
