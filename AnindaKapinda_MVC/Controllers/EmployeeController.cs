using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _appContext;

        public EmployeeController()
        {
            _appContext = new ApplicationDbContext();
        }


        public IActionResult PendingOrders()
        {
            var model = _appContext.Orders.ToList();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult PrepareOrder(int id)
        {
            var model = _appContext.Orders.Where(x => x.OrderID == id).FirstOrDefault();
            model.isPrepared = true;
            _appContext.SaveChanges();
            return View("PendingOrders");
        }
////////////////////////////////////////////////////////////
        
        public IActionResult PendingShipments()
        {
            return View();
        }
        
        public IActionResult DeliverSuccess()
        {
            return View();
        }
        
        public IActionResult DeliverFail()
        {
            return View();
        }
    }
}
