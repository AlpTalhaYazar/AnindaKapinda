using AnindaKapinda_MVC.Models;
using AnindaKapinda_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _appContext;
        private readonly AuthDbContext _authContext;
        private readonly IWebHostEnvironment _hostEnvironment;

        public AdministrationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, AuthDbContext authDbContext, IWebHostEnvironment hostEnvironment)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._appContext = new ApplicationDbContext();
            this._authContext = authDbContext;
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            IQueryable<IdentityRole> roles = _roleManager.Roles;
            ViewBag.roles = roles;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync(NewEmployeeViewModel newEmployee)
        {
            var role = await _roleManager.FindByIdAsync(newEmployee.RoleID);

            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = newEmployee.Employee.Email,
                    Email = newEmployee.Employee.Email
                };

                var result1 = await _userManager.CreateAsync(user, newEmployee.Employee.Password);  // Create User in Identity table
                var result2 = await _userManager.AddToRoleAsync(user, role.Name);                   // Give desired role to that user

                if (result1.Succeeded)
                {
                    newEmployee.Employee.EmployeeID = user.Id;          // Set the incoming model's ID to same ID as User at Identity table
                    _appContext.Employees.Add(newEmployee.Employee);    // Adding incoming model to our employee table with desired ID
                    _appContext.SaveChanges();                          //

                    return RedirectToAction();
                }
                foreach (var error in result1.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult DeleteEmployee(string id)
        {
            var model = _appContext.Employees.Find(id);
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEmployeeAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return RedirectToAction("Not Found", "Home");
            }
            else
            {
                var result = await _userManager.DeleteAsync(user);  // Delete User from Identity Table

                if (result.Succeeded)
                {
                    var model = _appContext.Employees.Find(id);     // Delete User from our 
                    _appContext.Employees.Remove(model);            // employee table
                    _appContext.SaveChanges();                      // 

                    return RedirectToAction("List", "Employee");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction("List", "Employee");
            }
        }
        /////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category category)
        {
            _appContext.Categories.Add(category);
            _appContext.SaveChanges();
            return RedirectToAction("List", "Category");
        }
        [HttpGet]
        public IActionResult EditCategory(int id)
        {
            var model = _appContext.Categories.Find(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            var model = _appContext.Categories.Find(category.CategoryID);
            model.Name = category.Name;
            _appContext.SaveChanges();

            return View();
        }
        /////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult AddProduct()
        {
            ViewBag.Categories = _appContext.Categories.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (ModelState.IsValid)
            {
                string ImageFileName;
                if (product.ImageFile == null)
                    product.Image = "preparing.png";
                else
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                    string extension = Path.GetExtension(product.ImageFile.FileName);
                    product.Image = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath + "/Image/", fileName);

                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await product.ImageFile.CopyToAsync(fileStream);
                    }
                }


                _appContext.Products.Add(product);
                _appContext.SaveChanges();
            }
            return RedirectToAction("List", "Product");
        }
        [HttpGet]
        public IActionResult EditProduct(string name)
        {
            var model = _appContext.Products.Where(x => x.Name == name).FirstOrDefault();
            ViewBag.Categories = _appContext.Categories.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            var model = _appContext.Products.Find(product.ProductID);

            model.Name = product.Name;
            model.Price = product.Price;
            model.DiscountRate = product.DiscountRate;
            model.Description = product.Description;
            model.Image = product.Image;
            model.CategoryID = product.CategoryID;

            _appContext.SaveChanges();
            return RedirectToAction("List", "Product");
        }
    }
}
