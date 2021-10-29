using AnindaKapinda_MVC.Models;
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
        private readonly ApplicationDbContext _context;
        
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._context = new ApplicationDbContext();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(IdentityUser identityUser, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(identityUser.Email, identityUser.PasswordHash, false,false);

                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return RedirectToAction(returnUrl);
                    }
                }
            }

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(string)

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
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
