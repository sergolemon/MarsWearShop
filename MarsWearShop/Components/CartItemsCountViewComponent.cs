using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Components
{
    public class CartItemsCountViewComponent : ViewComponent
    {
        readonly ICartService Cart;
        public CartItemsCountViewComponent(ICartService cart)
        {
            Cart = cart;
        }

        public async Task<ContentViewComponentResult> InvokeAsync()
        {
            int count = await Cart.GetItemsCount();

            return Content(count > 0 ? count.ToString() : "");
        }
    }
}
