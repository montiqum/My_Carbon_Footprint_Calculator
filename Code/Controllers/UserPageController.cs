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
            var currentUserState = _context.GenInfo.Where(v => v.UserId.Equals(currentUser.Id)).Single();
            ViewBag.state = currentUserState.State;
            var currentUserHouse = _context.House.Where(v => v.HouseId.Equals(currentUser.Id)).Single();
            var houseEmission = currentUserHouse.Energy_Usage / 45;
            // takes the currentUser object and then pulls the info from the vehicle table
            var currentUserVehicle = _context.Vehicle.Where(v => v.VehicleId.Equals(currentUser.Id)).Single();         
            var vehicleEmission = currentUserVehicle.Mileage / 2000;
            var currentUserFood = _context.Food.Where(v => v.DietId.Equals(currentUser.Id)).Single();
            var getMeatpercentage = currentUserFood.Meat;
            var getMilkpercentage = currentUserFood.Milk;
            var getFastfpercentage = currentUserFood.Fast_foods;
            var getDessertpercentage = currentUserFood.Desserts;
            var getFruitsVegpercentage = currentUserFood.Fruits + currentUserFood.Vegetables;
            var getGrainspercentage = currentUserFood.Grains;
            var getFishpercentage = currentUserFood.Fish;
            var totalamt = getMeatpercentage + getMilkpercentage + getFastfpercentage + getDessertpercentage;
            var wasteEmission = 0;
            if (totalamt > 50)
            {
                wasteEmission = getMeatpercentage / 5;
            }
            else
            {
                var fruitsandvegs = 0;
                var grains = 0;
                var fish = 0;
     
                if (getFruitsVegpercentage == 0)
                {
                    fruitsandvegs = 0;
                }
                else
                {
                    fruitsandvegs = 80 / getFruitsVegpercentage;
                }
                if (getGrainspercentage == 0)
                {
                    grains = 0;
                }
                else
                {
                    grains = 100 / getGrainspercentage;
                }
                if (getFishpercentage == 0)
                {
                    fish = 0;
                }
                else
                {
                    fish = 60 / getFishpercentage;
                }
                wasteEmission = (getMeatpercentage / 8) + fruitsandvegs + grains + fish;
            }
            
            var final = houseEmission + vehicleEmission + wasteEmission;
            if (final < 10)
            {
                final = 12;
            }
            if (final > 30)
            {
                final = 30;
            }
            ViewBag.Final = final;
            var rangeUS = "in the average range of 50 - 60%";
            var rangeState = "in the average range of 50 - 60%";
            if(final < 20)
            {
                rangeUS = "in the low range of below 50%";
                rangeState = "in the low range of below 50%";
            }
            else if(final == 20)
            {
                rangeUS = "right at the 50% average";
                rangeState = "right at the 50% average";
            }
            else if (final > 20 && final <= 22)
            {
                rangeUS = "in the low upper range of 50 - 60%";
                rangeState = "in the low upper range of 50 - 60%";
            }
            else if (final > 22 && final <= 24)
            {
                rangeUS = "in the mid upper range of 60 - 70%";
                rangeState = "in the mid upper range of 60 - 70%";
            }
            else if (final > 24 && final <= 26)
            {
                rangeUS = "in the mid-high upper range of 70 - 80%";
                rangeState = "in the mid-high upper range of 70 - 80%";
            }
            else if (final > 26 && final <= 28)
            {
                rangeUS = "in the mid-high upper range of 70 - 80%";
                rangeState = "in the mid-high upper range of 70 - 80%";
            }
            else if (final > 28 && final <= 30)
            {
                rangeUS = "in the high upper range of above 80%";
                rangeState = "in the high upper range of above 80%";
            }
            ViewBag.USrange = rangeUS;
            ViewBag.Staterange = rangeState;

            return View();
        }
    }
}
