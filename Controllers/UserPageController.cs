using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCarbonFootprintCalculator.Controllers
{
    public class UserPageController : Controller
    {
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
            return View();
        }
    }
}
