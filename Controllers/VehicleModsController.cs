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
    public class VehicleModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;

        public VehicleModsController(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }

        // GET: VehicleMods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicle.ToListAsync());
        }

        // GET: VehicleMods/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: VehicleMods/Create
        public IActionResult Create()
        {
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
            if (id == null)
            {
                return NotFound();
            }

            var vehicleMod = await _context.Vehicle.FindAsync(id);
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
                return RedirectToAction(nameof(Index));
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
