using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Areas.Admin.Controllers
{
    public class OrderController : BaseAdminController
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
