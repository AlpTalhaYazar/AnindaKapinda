using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _appContext;

        public ProductController()
        {
            _appContext = new ApplicationDbContext();
        }

        public IActionResult List()
        {
            var model = _appContext.Products.ToList();
            return View(model);
        }
        public IActionResult List(int id)
        {
            var model = _appContext.Products.Where(x => x.Category.CategoryID == id).ToList();
            return View(model);
        }

        //public JsonResult IsProductExists(string ProductName)
        //{
        //    //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  
        //    return Json(!db.Users.Any(x => x.UserName == ProductName), JsonRequestBehavior.AllowGet);
        //}
    }
}
