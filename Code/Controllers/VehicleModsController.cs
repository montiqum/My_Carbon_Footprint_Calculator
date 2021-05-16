using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCarbonFootprintCalculator.Data;
using MyCarbonFootprintCalculator.Models;

namespace MyCarbonFootprintCalculator.Controllers
{
    public class VehicleModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;
        private UserManager<User> _userManager;

        public VehicleModsController(MyCarbonFootprintCalculatorContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: VehicleMods
        public async Task<IActionResult> Index()
        {
            //pulls the currently logged in user's email address
            var userId = User.FindFirstValue(ClaimTypes.Name);
            //using the current user's email address, it it then used to find the user with that 
            // email address in the database. once found it returns the entire user object.
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            // takes the currentUser object and then pulls only the first and last name separated by a space
            if (currentUser.Id != 1)
            {
                return RedirectToAction("Create", new { Id = currentUser.Id });
            }
            return View(await _context.Vehicle.ToListAsync());
        }

        // GET: VehicleMods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMod = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleMod == null)
            {
                return NotFound();
            }

            return View(vehicleMod);
        }

        // GET: VehicleMods/Create
        public IActionResult Create()
        {
            //pulls the currently logged in user's email address
            var userId = User.FindFirstValue(ClaimTypes.Name);
            //using the current user's email address, it it then used to find the user with that 
            // email address in the database. once found it returns the entire user object.
            var currentUser = (User)_userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            // takes the currentUser object and then pulls only the first and last name separated by a space
            //ViewBag.CurrentUser = currentUser.FirstName + " " + currentUser.LastName;
            ViewBag.CurrentUserId = currentUser.Id;
            //_userManager.AddToRoleAsync(currentUser, "Admin");
            if (_context.Vehicle.Find(currentUser.Id) != null)
            {
                return RedirectToAction("Details", new { Id = currentUser.Id }); ;
            }
            return View();
        }

        // POST: VehicleMods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,NoOfVehicles,Year,Make,Model,Mileage")] VehicleMod vehicleMod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleMod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "FoodMods");
            }
            return View(vehicleMod);
        }

        // GET: VehicleMods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var vehicleMod = await _context.Vehicle.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = (User)_userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            var test = _context.Vehicle.Where(t => t.VehicleId.Equals(currentUser.Id)).Single();
            var getUserID = test.VehicleId;
            if (currentUser.Id == 1)
            {
                if (vehicleMod == null)
                {
                    return RedirectToAction("Index");
                }
                return View(vehicleMod);
            }
            if (getUserID != id)
            {
                return RedirectToAction("Create");
            }
            if (id == null)
            {
                return NotFound();
            } 
            if (vehicleMod == null)
            {
                return NotFound();
            }
            return View(vehicleMod);
        }

        // POST: VehicleMods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,NoOfVehicles,Year,Make,Model,Mileage")] VehicleMod vehicleMod)
        {
            if (id != vehicleMod.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleMod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleModExists(vehicleMod.VehicleId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Create", "FoodMods");
            }
            return View(vehicleMod);
        }

        // GET: VehicleMods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMod = await _context.Vehicle
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicleMod == null)
            {
                return NotFound();
            }

            return View(vehicleMod);
        }

        // POST: VehicleMods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicleMod = await _context.Vehicle.FindAsync(id);
            _context.Vehicle.Remove(vehicleMod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleModExists(int id)
        {
            return _context.Vehicle.Any(e => e.VehicleId == id);
        }
    }
}
