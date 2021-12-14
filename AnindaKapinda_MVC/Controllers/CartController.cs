using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _appContext;
        public CartController()
        {
            this._appContext = new ApplicationDbContext();
        }

        [Authorize(Roles = "ConfirmedClient")]
        public IActionResult List()
        {
            var model = _appContext.Carts.Include(x => x.CartProducts).ToList();
            return View(model);
        }
    }
}
