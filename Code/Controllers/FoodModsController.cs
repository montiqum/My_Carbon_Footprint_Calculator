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
    public class FoodModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;
        private UserManager<User> _userManager;

        public FoodModsController(MyCarbonFootprintCalculatorContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FoodMods
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
            return View(await _context.Food.ToListAsync());
        }

        // GET: FoodMods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            if (id == null)
            {
                return NotFound();
            }

            var foodMod = await _context.Food
                .FirstOrDefaultAsync(m => m.DietId == id);
            if (foodMod == null)
            {
                return NotFound();
            }

            return View(foodMod);
        }

        // GET: FoodMods/Create
        public IActionResult Create()
        {
            //pulls the currently logged in user's email address
            var userId = User.FindFirstValue(ClaimTypes.Name);
            //using the current user's email address, it it then used to find the user with that 
            // email address in the database. once found it returns the entire user object.
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            // takes the currentUser object and then pulls only the first and last name separated by a space
            //ViewBag.CurrentUser = currentUser.FirstName + " " + currentUser.LastName;
            ViewBag.CurrentUserId = currentUser.Id;
            //_userManager.AddToRoleAsync(currentUser, "Admin");
            if (_context.Food.Find(currentUser.Id) != null)
            {
                return RedirectToAction("Details", new { Id = currentUser.Id }); ;
            }
            return View();
        }

        // POST: FoodMods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DietId,DietType,Grains,Meat,Vegetables,Fruits,Fish,Milk,Desserts,Fast_foods")] FoodMod foodMod)
        {
            var total = foodMod.Grains + foodMod.Meat + foodMod.Vegetables + foodMod.Fruits + foodMod.Fish + foodMod.Milk + foodMod.Desserts + foodMod.Fast_foods;

            if (ModelState.IsValid && total == 100)
            {
                _context.Add(foodMod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Footprint", "UserPage");
            }
            ViewBag.errormessage = "Total percentages not equal to 100%";
            return View(foodMod);
        }

        // GET: FoodMods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var foodMod = await _context.Food.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = (User)_userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            var test = _context.Food.Where(t => t.DietId.Equals(currentUser.Id)).Single();
            var getUserID = test.DietId;
            if (currentUser.Id == 1)
            {
                if (foodMod == null)
                {
                    return RedirectToAction("Index");
                }
                return View(foodMod);
            }
            if (getUserID != id)
            {
                return RedirectToAction("Create");
            }
            if (id == null)
            {
                return NotFound();
            } 
            if (foodMod == null)
            {
                return NotFound();
            }
            return View(foodMod);
        }

        // POST: FoodMods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DietId,DietType,Grains,Meat,Vegetables,Fruits,Fish,Milk,Desserts,Fast_foods")] FoodMod foodMod)
        {
            var total = foodMod.Grains + foodMod.Meat + foodMod.Vegetables + foodMod.Fruits + foodMod.Fish + foodMod.Milk + foodMod.Desserts + foodMod.Fast_foods;
            if (id != foodMod.DietId)
            {
                return NotFound();
            }

            if (ModelState.IsValid && total == 100)
            {
                try
                {
                    _context.Update(foodMod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FoodModExists(foodMod.DietId))
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
            ViewBag.errormessage = "Total percentages not equal to 100%";
            return View(foodMod);
        }

        // GET: FoodMods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodMod = await _context.Food
                .FirstOrDefaultAsync(m => m.DietId == id);
            if (foodMod == null)
            {
                return NotFound();
            }

            return View(foodMod);
        }

        // POST: FoodMods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var foodMod = await _context.Food.FindAsync(id);
            _context.Food.Remove(foodMod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FoodModExists(int id)
        {
            return _context.Food.Any(e => e.DietId == id);
        }
    }
}
