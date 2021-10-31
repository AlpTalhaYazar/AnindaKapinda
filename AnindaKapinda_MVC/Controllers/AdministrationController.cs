using AnindaKapinda_MVC.Models;
using AnindaKapinda_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        private readonly ApplicationDbContext _context;

        public AdministrationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._context = new ApplicationDbContext();
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

                var result1 = await _userManager.CreateAsync(user, newEmployee.Employee.Password);
                var result2 = await _userManager.AddToRoleAsync(user, role.Name);

                if (result1.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    _context.Employees.Add(newEmployee.Employee);
                    _context.SaveChanges();

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
        public IActionResult DeleteEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DeleteEmployee(Employee employee)
        {
            var employee1 = _context.Employees.Find(employee.EmployeeID);
            employee1.Status = false;
            _context.SaveChanges();
            return View();
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
            return View();
        }
        [HttpGet]
        public IActionResult EditCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            return View();
        }
        /////////////////////////////////////////////////////////////
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            return View();
        }
    }
}
