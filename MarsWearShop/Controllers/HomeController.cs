using MarsWearShop.Classes;
using MarsWearShop.Data;
using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MarsWearShop.Controllers
{
    public class HomeController : Controller
    {
        readonly ICatalogService Catalog;
        public HomeController(ICatalogService catalog)
        {
            Catalog = catalog;
        }

        public async Task<IActionResult> Index()
        {
            return View(await Catalog.GetProductsOnMainPage());
        }

        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
