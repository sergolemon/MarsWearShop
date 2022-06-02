using MarsWearShop.Data.ViewModels;
using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Controllers
{
    public class CatalogController : Controller
    {
        readonly ICatalogService Catalog;

        public CatalogController(ICatalogService catalog)
        {
            Catalog = catalog;
        }

        [HttpGet, Route("catalog/{**categories}")]
        public async Task<IActionResult> Index(string categories)
        {
            return View(new CatalogVM { Products = await Catalog.GetProducts(categories), Categories = await Catalog.GetCategories(categories) });
        }

        [HttpPost, Route("catalog/{**categories}")]
        public async Task<IActionResult> Index(string categories, int index)
        {
            return PartialView("_ProductsList", await Catalog.GetProducts(categories, index));
        }

        [HttpGet, Route("discount")]
        public async Task<IActionResult> Discount()
        {
            return View(await Catalog.GetProductsOnDiscountPage());
        }

        [HttpPost, Route("discount")]
        public async Task<IActionResult> Discount(int index)
        {
            return PartialView("_ProductsList",await Catalog.GetProductsOnDiscountPage(index));
        }


        [Route("catalog/product/{id}")]
        public async Task<IActionResult> Product(int id)
        {
            return View(await Catalog.GetProduct(id));
        }
    }
}
