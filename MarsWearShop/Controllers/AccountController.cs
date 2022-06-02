using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsWearShop.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public JsonResult Login(string login, string password)
        {
            return Json(new { success = false, msg = "Неверный логин или пароль" });
        }
    }
}
