using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly ApplicationDbContext _appContext;

        public ClientController()
        {
            _appContext = new ApplicationDbContext();
        }

        public IActionResult List(Client client)
        {
            var model = _appContext.Carts.Where(x => x.Client == client).ToList();
            return View(model);
        }

        public IActionResult Order()
        {
            return View();
        }
       
    }
}
