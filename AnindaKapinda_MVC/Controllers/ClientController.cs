using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class ClientController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _appContext;

        public ClientController(UserManager<IdentityUser> userManager)
        {
            this._appContext = new ApplicationDbContext();
            this._userManager = userManager;
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult AddtoCart(Product product)
        {
            var CartProducts = new CartProduct { Product = product.Name, Price = product.DiscountedPrice };
            var model = new Cart { CartProducts = (ICollection<CartProduct>)CartProducts, ClientID = _userManager.GetUserId(User) };

            return View();
        }

        public IActionResult Order(Cart cart)
        {
            var model = _appContext.Carts.Find(cart.CartID);
            return View();
        }
        [HttpPost]
        public IActionResult Order(Address address, CreditCard creditCard)
        {
            return View();
        }

    }
}
