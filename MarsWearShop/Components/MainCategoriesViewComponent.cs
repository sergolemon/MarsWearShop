using MarsWearShop.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Components
{
    public class MainCategoriesViewComponent : ViewComponent
    {
        readonly ICatalogService Catalog;
        public MainCategoriesViewComponent(ICatalogService catalog)
        {
            Catalog = catalog;
        }

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            return View(await Catalog.GetMainCategories());
        }
    }
}
