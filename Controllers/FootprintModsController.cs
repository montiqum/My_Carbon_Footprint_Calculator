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
    public class FootprintModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;

        public FootprintModsController(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }

        // GET: FootprintMods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Footprint.ToListAsync());
        }

        // GET: FootprintMods/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: FootprintMods/Create
        public IActionResult Create()
        {
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
            if (id == null)
            {
                return NotFound();
            }

            var footprintMod = await _context.Footprint.FindAsync(id);
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
