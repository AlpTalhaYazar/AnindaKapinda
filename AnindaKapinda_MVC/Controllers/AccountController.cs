using AnindaKapinda_MVC.Models;
using AnindaKapinda_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
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
            //    Name = "Confirmed CLient"
            //};

            //IdentityResult result = await _roleManager.CreateAsync(identityRole);

            var user = _userManager.FindByNameAsync(User.Identity.Name);

            await _userManager.AddToRoleAsync(await user, "ConfirmedClient");
            return View();
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync(LoginViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null && !user.EmailConfirmed && (await _userManager.CheckPasswordAsync(user, model.Password)))
                {
                    ModelState.AddModelError(string.Empty, "Email not confirmed yet.");             // Checking if user confirmed email 
                    return View(model);                                                             // and blocking if not confirmed
                }

                // var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                // creates hash error so changed to below

                var signedUser = _userManager.FindByEmailAsync(model.Email);
                var result = await _signInManager.PasswordSignInAsync(await signedUser, model.Password, model.RememberMe, false);

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
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
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
                    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                    var confirmationLink = Url.Action("ConfirmEmail", "Account",
                                            new { userId = user.Id, token = token }, Request.Scheme);

                    SendConfirmationMail(user.Email, confirmationLink);

                    //await _signInManager.SignInAsync(user, false);      //Automatic login after registration

                    client.ClientID = user.Id;          // Set the incoming model's ID to same ID as User at Identity table
                    _context.Clients.Add(client);       // Adding incoming model to our client table with desired ID
                    _context.SaveChanges();             //

                    ViewBag.ErrorTitle = "Registration successful";
                    ViewBag.ErrorMessage = "Before you can Login, please confirm your email, by clicking on the confirmation link we have emailed you";
                    return View("EmailConfirmError");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
        [AllowAnonymous]
        public IActionResult SendConfirmationMail(string confirmationEmail, string confirmationLink)
        {

            MimeMessage message = new MimeMessage();

            MailboxAddress from = new MailboxAddress("AnindaKapindaSystem",
            "techcareershare@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("New Member",
            confirmationEmail);
            message.To.Add(to);

            message.Subject = "Resgistration confirmation";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = confirmationLink;

            message.Body = bodyBuilder.ToMessageBody();

            //////////

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("techcareershare@gmail.com", "-Tech20+21Career-");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("index", "home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"The User ID {userId} is invalid";
                return View("NotFound");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
            {
                return View();
            }

            ViewBag.ErrorTitle = "Email cannot be confirmed";
            return View("EmailConfirmError");
        }


    }
}
