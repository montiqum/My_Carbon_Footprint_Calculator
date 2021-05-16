using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCarbonFootprintCalculator.Data;
using MyCarbonFootprintCalculator.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace MyCarbonFootprintCalculator.Controllers
{
    public class GenInfoModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;
        private UserManager<User> _userManager;


        Location getlocation = new Location();

        public GenInfoModsController(MyCarbonFootprintCalculatorContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
            
        }

        // GET: GenInfoMods
        //[Authorize(Roles = "Admin")]
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
            return View(await _context.GenInfo.ToListAsync());
        }

        // GET: GenInfoMods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            if (id == null)
            {
                return NotFound();
            }

            var genInfoMod = await _context.GenInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (genInfoMod == null)
            {
                return NotFound();
            }

            return View(genInfoMod);
        }

        // GET: GenInfoMods/Create
        public IActionResult Create()
        {
            //pulls the currently logged in user's email address
            var userId = User.FindFirstValue(ClaimTypes.Name);
            //using the current user's email address, it it then used to find the user with that 
            // email address in the database. once found it returns the entire user object.
            var currentUser = (User) _userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            // takes the currentUser object and then pulls only the first and last name separated by a space
            ViewBag.CurrentUser = currentUser.FirstName + " " + currentUser.LastName;           
            ViewBag.CurrentUserId = currentUser.Id;
            //_userManager.AddToRoleAsync(currentUser, "Admin");
            var test = _context.GenInfo.Where(u => u.UserId.Equals(currentUser.Id));
           
            if (_context.GenInfo.Find(currentUser.Id) != null)
            {
                if(currentUser.Id == 1)
                {
                    return View();
                }
                return RedirectToAction("Details", new { Id = currentUser.Id });
            }
            
            return View();
        }

        // POST: GenInfoMods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,City,State,ZipCode,AnnualIncome")] GenInfoMod genInfoMod)
        {
            getlocation = await Location.Lookup(genInfoMod.ZipCode);

            genInfoMod.City = getlocation.City;
            genInfoMod.State = getlocation.State;
            genInfoMod.ZipCode = getlocation.Zip;
            if (ModelState.IsValid)
            {
                _context.Add(genInfoMod);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "HouseMods");
            }
            return View(genInfoMod);
        }

        // GET: GenInfoMods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var genInfoMod = await _context.GenInfo.FindAsync(id);
            var userId = User.FindFirstValue(ClaimTypes.Name);
            var currentUser = (User)_userManager.Users.Where(x => x.Email.Equals(userId)).Single();
            ViewBag.CurrentUserId = currentUser.Id;
            var test = _context.GenInfo.Where(t => t.UserId.Equals(currentUser.Id)).Single();
            var getUserID = test.UserId;
            if (currentUser.Id == 1)
            {
                if (genInfoMod == null)
                {
                    return RedirectToAction("Index");
                }
                return View(genInfoMod);
            }
            if (getUserID != id)
            {
                return RedirectToAction("Create");
            }          
            if (id == null)
            {
                return NotFound();
            }           
            if (genInfoMod == null)
            {
                return NotFound();
                
            }
            return View(genInfoMod);
        }

        // POST: GenInfoMods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,City,State,ZipCode,AnnualIncome")] GenInfoMod genInfoMod)
        {
            if (id != genInfoMod.UserId)
            {
                return NotFound();
            }
            getlocation = await Location.Lookup(genInfoMod.ZipCode);

            genInfoMod.City = getlocation.City;
            genInfoMod.State = getlocation.State;
            genInfoMod.ZipCode = getlocation.Zip;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genInfoMod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenInfoModExists(genInfoMod.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Create));
            }
            return View(genInfoMod);
        }

        // GET: GenInfoMods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genInfoMod = await _context.GenInfo
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (genInfoMod == null)
            {
                return NotFound();
            }

            return View(genInfoMod);
        }

        // POST: GenInfoMods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genInfoMod = await _context.GenInfo.FindAsync(id);
            _context.GenInfo.Remove(genInfoMod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenInfoModExists(int id)
        {
            return _context.GenInfo.Any(e => e.UserId == id);
        }
    }
}
