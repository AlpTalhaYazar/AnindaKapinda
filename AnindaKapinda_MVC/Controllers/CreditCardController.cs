using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class CreditCardController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _appContext;

        public CreditCardController(UserManager<IdentityUser> userManager)
        {
            this._appContext = new ApplicationDbContext();
            this._userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCard(CreditCard creditCard)
        {
            creditCard.ClientID = _userManager.GetUserId(User);

            _appContext.CreditCards.Add(creditCard);
            _appContext.SaveChanges();

            return View();
        }

    }
}
