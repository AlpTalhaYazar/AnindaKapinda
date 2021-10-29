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
        [Authorize("Supply Center Worker")]
        public IActionResult PendingOrders()
        {
            return View();
        }
        [Authorize("Supply Center Worker")]
        [HttpPost]
        public IActionResult PrepareOrder()
        {
            return View();
        }

        [Authorize("Courier")]
        public IActionResult PendingShipments()
        {
            return View();
        }
        [Authorize("Courier")]
        public IActionResult DeliverSuccess()
        {
            return View();
        }
        [Authorize("Courier")]
        public IActionResult DeliverFail()
        {
            return View();
        }
    }
}
