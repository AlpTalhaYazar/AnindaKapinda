using AnindaKapinda_MVC.Models;
using AnindaKapinda_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    
    public class AccountController : Controller
    {
        
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._roleManager = roleManager;
            this._context = new ApplicationDbContext();
        }
        
        public async Task<IActionResult> IndexAsync()
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = "CLient"
            };

            IdentityResult result = await _roleManager.CreateAsync(identityRole);

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);

                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt.");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Logout(string handler)
        {
            if (handler == "Logout")
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Login");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Client client)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = client.Email,
                    Email = client.Email
                };

                var result = await _userManager.CreateAsync(user, client.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);

                    _context.Clients.Add(client);
                    _context.SaveChanges();

                    return RedirectToAction();
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
