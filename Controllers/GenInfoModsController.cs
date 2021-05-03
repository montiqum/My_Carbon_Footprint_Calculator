using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyCarbonFootprintCalculator.Data;
using MyCarbonFootprintCalculator.Models;

namespace MyCarbonFootprintCalculator.Controllers
{
    public class GenInfoModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;

        public GenInfoModsController(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }

        // GET: GenInfoMods
        public async Task<IActionResult> Index()
        {
            //var newUser = new GenInfoMod();
            return View(await _context.GenInfo.ToListAsync());
        }

        // GET: GenInfoMods/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: GenInfoMods/Create
        public IActionResult Create()
        {
            ViewBag.message = "1";
            return View();
        }

        // POST: GenInfoMods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,City,State,ZipCode,AnnualIncome")] GenInfoMod genInfoMod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genInfoMod);
                await _context.SaveChangesAsync();          
                return RedirectToAction("Create", "HouseMods");
            }
            return View(genInfoMod);
        }

        // GET: GenInfoMods/Edit/5
        //[Route("GenInfoMods/Admin/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genInfoMod = await _context.GenInfo.FindAsync(id);
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
                return RedirectToAction(nameof(Index));
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
        public IActionResult Next()
        {
            var userPage = _context.House;
            return View(userPage);
        }
    }
}
