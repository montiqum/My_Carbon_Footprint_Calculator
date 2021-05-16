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
    public class FootprintModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;
        private UserManager<User> _userManager;

        public FootprintModsController(MyCarbonFootprintCalculatorContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FootprintMods
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
            return View(await _context.Footprint.ToListAsync());
        }

        // GET: FootprintMods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            if (id == null)
            {
                return NotFound();
            }

            var footprintMod = await _context.Footprint
                .FirstOrDefaultAsync(m => m.CFPId == id);
            if (footprintMod == null)
            {
                return NotFound();
            }

            return View(footprintMod);
        }

        // GET: FootprintMods/Create
        public IActionResult Create()
        {
            //pulls the currently logged in user's email address
            var userId = User.FindFirstValue(ClaimTypes.Name);
            //using the current user's email address, it it then used to find the user with that 
            // email address in the database. once found it returns the entire user object.
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            //var currentUser1 = _context.Vehicle.Where(x => x.VehicleId.Equals(userId)).Single();
            // takes the currentUser object and then pulls only the first and last name separated by a space           
            if (_context.Footprint.Find(currentUser.Id) != null)
            {
                return RedirectToAction("Details", new { Id = currentUser.Id }); ;
            }
            return View();
        }

        // POST: FootprintMods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CFPId,Travel_emm,HH_Emm,Waste_emm,Total_emm")] FootprintMod footprintMod)
        {
            
            if (ModelState.IsValid)
            {
                _context.Add(footprintMod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footprintMod);
        }

        // GET: FootprintMods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var footprintMod = await _context.Footprint.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = (User)_userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            var test = _context.Footprint.Where(t => t.CFPId.Equals(currentUser.Id)).Single();
            var getUserID = test.CFPId;
            if (currentUser.Id == 1)
            {
                if(footprintMod == null)
                {
                    return NotFound();
                }
                return View(footprintMod);
            }
            if (getUserID != id)
            {
                return RedirectToAction("Create");
            }
            if (id == null)
            {
                return NotFound();
            }
            if (footprintMod == null)
            {
                return NotFound();
            }
            return View(footprintMod);
        }

        // POST: FootprintMods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CFPId,Travel_emm,HH_Emm,Waste_emm,Total_emm")] FootprintMod footprintMod)
        {
            if (id != footprintMod.CFPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(footprintMod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootprintModExists(footprintMod.CFPId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(footprintMod);
        }

        // GET: FootprintMods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var footprintMod = await _context.Footprint
                .FirstOrDefaultAsync(m => m.CFPId == id);
            if (footprintMod == null)
            {
                return NotFound();
            }

            return View(footprintMod);
        }

        // POST: FootprintMods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var footprintMod = await _context.Footprint.FindAsync(id);
            _context.Footprint.Remove(footprintMod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootprintModExists(int id)
        {
            return _context.Footprint.Any(e => e.CFPId == id);
        }
    }
}
