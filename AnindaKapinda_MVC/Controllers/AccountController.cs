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
            //IdentityRole identityRole = new IdentityRole
            //{
            //    Name = "CLient"
            //};

            //IdentityResult result = await _roleManager.CreateAsync(identityRole);

            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel model, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);

                if (result.Succeeded)
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
        public async Task<IActionResult> LogoutAsync(string handler)
        {
            if (handler == "Logout")
            {
                await _signInManager.SignOutAsync();        // Logout method
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
        public async Task<IActionResult> RegisterAsync(Client client)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = client.Email,
                    Email = client.Email
                };

                var result = await _userManager.CreateAsync(user, client.Password); // Create User in Identity table
                var result2 = await _userManager.AddToRoleAsync(user, "Client");

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);      //Automatic login after registration

                    client.ClientID = user.Id;          // Set the incoming model's ID to same ID as User at Identity table
                    _context.Clients.Add(client);       // Adding incoming model to our client table with desired ID
                    _context.SaveChanges();             //

                    return RedirectToAction("List", "Category");
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
