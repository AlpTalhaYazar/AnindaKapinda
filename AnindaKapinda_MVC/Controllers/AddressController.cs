using AnindaKapinda_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnindaKapinda_MVC.Controllers
{
    [Authorize(Roles = "Client,ConfirmedClient")]
    public class AddressController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _appContext;

        public AddressController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._appContext = new ApplicationDbContext();
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult AddAddress()
        {
            ViewBag.Cities = _appContext.Cities.OrderBy(x=>x.Name).ToList();
            ViewBag.Districts = _appContext.Districts.OrderBy(x => x.Name).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAddress(Address address)
        {
            int cityid = Convert.ToInt32(address.City);
            int districtid = Convert.ToInt32(address.District);
            address.City = _appContext.Cities.Where(x => x.CityID == cityid)
                                             .Select(x => x.Name)
                                             .FirstOrDefault();
            address.District = _appContext.Districts.Where(x => x.DistrictID == districtid)
                                                    .Select(x => x.Name)
                                                    .FirstOrDefault();
            address.ClientID = _userManager.GetUserId(User);

            _appContext.Addresses.Add(address);
            _appContext.SaveChanges();

            var user = _userManager.FindByEmailAsync(User.Identity.Name);
            await _userManager.AddToRoleAsync(await user, "ConfirmedClient");

            return RedirectToAction("List", "Category");
        }

        public JsonResult DistrictList(string id)
        {
            int cityid = Convert.ToInt32(id);
            var districts = _appContext.Districts.Where(x => x.CityID == cityid)
                                                 .Select(x => new
                                                 {
                                                     id = x.DistrictID,
                                                     name = x.Name
                                                 }).ToList();

            return new JsonResult(districts);
        }
    }
}
