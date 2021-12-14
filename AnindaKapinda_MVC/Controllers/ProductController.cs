using AnindaKapinda_MVC.Models;
using AnindaKapinda_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _appContext;

        public ProductController()
        {
            this._appContext = new ApplicationDbContext();
        }
        [HttpGet]
        public IActionResult List()
        {
            var model1 = _appContext.Products.Include(x=>x.Category);
            //var model2 = new ProductListViewModel
            //                {
            //                    Name = model1.Select(x => x.Name).FirstOrDefault(),
            //                    Price = model1.Select(x => x.Price).FirstOrDefault(),
            //                    DiscountedPrice = model1.Select(x => x.DiscountedPrice).FirstOrDefault(),
            //                    Description = model1.Select(x => x.Description).FirstOrDefault(),
            //                    Image = model1.Select(x => x.Image).FirstOrDefault(),
            //                    Category = model1.Select(x => x.Category.Name).FirstOrDefault(),
            //                };
            return View(model1);
        }
        [HttpGet]
        public IActionResult List2()
        {
            var model1 = _appContext.Products.Include(x=>x.Category);
            //var model2 = new ProductListViewModel
            //                {
            //                    Name = model1.Select(x => x.Name).FirstOrDefault(),
            //                    Price = model1.Select(x => x.Price).FirstOrDefault(),
            //                    DiscountedPrice = model1.Select(x => x.DiscountedPrice).FirstOrDefault(),
            //                    Description = model1.Select(x => x.Description).FirstOrDefault(),
            //                    Image = model1.Select(x => x.Image).FirstOrDefault(),
            //                    Category = model1.Select(x => x.Category.Name).FirstOrDefault(),
            //                };
            return View(model1);
        }
        public IActionResult ListbyCategory(int id)
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
