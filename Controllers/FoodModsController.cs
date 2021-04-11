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
    public class FoodModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;

        public FoodModsController(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }

        // GET: FoodMods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Food.ToListAsync());
        }

        // GET: FoodMods/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: FoodMods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FoodMods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DietId,DietType,Grains,Meat,Vegetables,Fruits,Fish,Milk,Desserts,Fast_foods")] FoodMod foodMod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(foodMod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(foodMod);
        }

        // GET: FoodMods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var foodMod = await _context.Food.FindAsync(id);
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
            if (id != foodMod.DietId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
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
                return RedirectToAction(nameof(Index));
            }
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
