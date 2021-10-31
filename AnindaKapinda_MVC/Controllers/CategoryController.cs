using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _appContext;
        public CategoryController()
        {
            this._appContext = new ApplicationDbContext();
        }
        
        public IActionResult List()
        {
            var model = _appContext.Categories.ToList();
            return View(model);
        }
    }
}
