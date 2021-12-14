using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _appContext;

        public EmployeeController()
        {
            this._appContext = new ApplicationDbContext();
        }

        [Authorize(Roles = "SupplyCenterOfficer")]
        public IActionResult PendingOrders()
        {
            //Order model = _appContext.Orders.Where(x => x.OrderStatus == Enumerations.OrderStatus.Status0).FirstOrDefault();
            var model = _appContext.Orders.Where(x => x.OrderStatus == Enumerations.OrderStatus.Status0).ToList();
            return View(model);
        }        
        [HttpPost]
        [Authorize(Roles = "SupplyCenterOfficer")]
        public IActionResult PrepareOrder(int id)
        {
            var model = _appContext.Orders.Where(x => x.OrderID == id).FirstOrDefault();
            model.OrderStatus = Enumerations.OrderStatus.Status1;
            _appContext.SaveChanges();
            return View("PendingOrders", _appContext.Orders.Where(x => x.OrderStatus == Enumerations.OrderStatus.Status0).ToList());
        }

        ////////////////////////////////////////////////////////////

        [Authorize(Roles = "Courier")]
        public IActionResult PendingShipments()
        {
            var model = _appContext.Orders.Where(x => x.OrderStatus == Enumerations.OrderStatus.Status1).ToList();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Courier")]
        public IActionResult Deliver(int id)
        {
            //_appContext.Orders.Where()
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Courier")]
        public IActionResult Deliver(int id, string handler)
        {
            return View();
        }
    }


    public static class EnumExtensions
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
}
