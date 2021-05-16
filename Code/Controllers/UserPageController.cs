using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using MyCarbonFootprintCalculator.Models;
using MyCarbonFootprintCalculator.Data;

namespace MyCarbonFootprintCalculator.Controllers
{
    public class UserPageController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;
        private UserManager<User> _userManager;

        public UserPageController(MyCarbonFootprintCalculatorContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult General(int ID = 0, string name = "Guest")
        {
            ViewData["Message1"] = "ID " + ID;
            ViewData["Message"] = "Welcome " + name; 
            return View();
        }
        public IActionResult House()
        {
            return View();
        }
        public IActionResult Vehicles()
        {
            return View();
        }
        public IActionResult Food()
        {
            return View();
        }
        public IActionResult Footprint()
        {
            //pulls the currently logged in user's email address
            var userId = User.FindFirstValue(ClaimTypes.Name);
            //using the current user's email address, it it then used to find the user with that 
            // email address in the database. once found it returns the entire user object.
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.currentUserName = currentUser.FirstName;
            
            if (_context.GenInfo.Find(currentUser.Id) == null)
            {
                return RedirectToAction("Create", "GenInfoMods", new { Id = currentUser.Id }); ;
            }
            else if (_context.House.Find(currentUser.Id) == null)
            {
                return RedirectToAction("Create", "HouseMods", new { Id = currentUser.Id }); ;
            }
            else if (_context.Vehicle.Find(currentUser.Id) == null)
            {
                return RedirectToAction("Create", "VehicleMods", new { Id = currentUser.Id }); ;
            }
            else if (_context.Food.Find(currentUser.Id) == null)
            {
                return RedirectToAction("Create", "FoodMods", new { Id = currentUser.Id }); ;
            }
            // takes the currentUser object and then pulls the info from the vehicle table
            var currentUserData = _context.Vehicle.Where(v => v.VehicleId.Equals(currentUser.Id)).Single();         
            var t_emm = currentUserData.Mileage * 1;
            ViewBag.Test = t_emm;

            return View();
        }
    }
}
