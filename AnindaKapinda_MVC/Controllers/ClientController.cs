using AnindaKapinda_MVC.Models;
using AnindaKapinda_MVC.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        [Authorize(Roles = "ConfirmedClient")]
        public IActionResult AddtoCart(int id)
        {
            Cart model;
            if (!_appContext.Carts.Where(x => x.ClientID == _userManager.GetUserId(User)).Any())
            {
                model = new Cart { ClientID = _userManager.GetUserId(User) };
                _appContext.Carts.Add(model);
                _appContext.SaveChanges();
            }
            else
                model = _appContext.Carts.Where(x => x.ClientID == _userManager.GetUserId(User))
                                         .FirstOrDefault();

            var addedproduct = _appContext.Products.Where(x => x.ProductID == id)
                                                   .FirstOrDefault();

            var CartProducts = new CartProduct
            {
                Product = addedproduct.Name,
                Price = addedproduct.DiscountedPrice,
                CartID = model.CartID
            };

            _appContext.CartProducts.Add(CartProducts);

            _appContext.SaveChanges();

            return RedirectToAction("List2", "Product");
        }

        [Authorize(Roles = "ConfirmedClient")]
        public IActionResult Order()
        {
            ICollection<Address> addresses = _appContext.Addresses.Where(x => x.ClientID == _userManager.GetUserId(User)).ToList();
            ICollection<CreditCard> creditCards = _appContext.CreditCards.Where(x => x.ClientID == _userManager.GetUserId(User)).ToList();
            ICollection<string> products = _appContext.CartProducts.Where(x => x.Cart.ClientID == _userManager.GetUserId(User)).GroupBy(x => x.Product).Select(x => x.Key).ToList();
            ICollection<decimal> prices = _appContext.Products.Where(x => products.Contains(x.Name)).Select(x => x.DiscountedPrice).ToList();
            ICollection<int> amounts = _appContext.CartProducts.GroupBy(x => x.Product).Select(x => x.ToList().Count()).ToList();
            decimal total = _appContext.CartProducts.Sum(x => x.Price);

            OrderViewModel ordermodel = new OrderViewModel
            {
                Addresses = addresses,
                CreditCards = creditCards,
                Products = products,
                Prices = prices,
                Amounts = amounts,
                Total = total
            };

            return View(ordermodel);
        }
        [HttpPost]
        [Authorize(Roles = "ConfirmedClient")]
        public IActionResult Order(IFormCollection keyValuePairs)
        {
            var model1 = _appContext.CartProducts.Where(x => x.Cart.ClientID == _userManager.GetUserId(User)).FirstOrDefault();
            var model2 = _appContext.Carts.Where(x => x.ClientID == _userManager.GetUserId(User)).FirstOrDefault();
            _appContext.CartProducts.Remove(model1);
            _appContext.Carts.Remove(model2);

            // var values = keyValuePairs.Where(x=>x.Key.Contains("product")).ToList();

            if (ModelState.IsValid)
            {
                var orderModel = new Order
                {
                    OrderStatus = Enumerations.OrderStatus.Status0,
                    DeliveryStatus = Enumerations.DeliveryStatus.Status0
                };

                _appContext.Orders.Add(orderModel);
                _appContext.SaveChanges();

                var orderProductModel = new OrderProduct();

                for (int i = 2, j=0; j < (keyValuePairs.Count() - 4)/3; i+=3, j++)
                {
                    _appContext.OrderProducts.Add(new OrderProduct
                    {
                        Products = keyValuePairs.ToList()[i].ToString(),
                        OrderID = _appContext.Orders.Max(x=>x.OrderID)
                    });
                    _appContext.SaveChanges();


                };
                return View("PaymentSuccess");
            }
            else
                return RedirectToAction("Order", "Client");
        }
    }
}
