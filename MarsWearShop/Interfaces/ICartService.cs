using MarsWearShop.Data.Models;
using MarsWearShop.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Interfaces
{
    public interface ICartService
    {
        public Task<int> GetItemsCount();
        public Task<IEnumerable<CartItemVM>> GetCart();
        public Task<int> AddItem(int productId, string size);
        public Task DeleteItem(int id);
        public Task<int> PlusItem(int id);
        public Task<int> MinusItem(int id);
        public Task ClearCart();
        public Task<CartItemVM> GetLastItem();
    }
}
