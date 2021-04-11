﻿using System;
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
    public class HouseModsController : Controller
    {
        private readonly MyCarbonFootprintCalculatorContext _context;

        public HouseModsController(MyCarbonFootprintCalculatorContext context)
        {
            _context = context;
        }

        // GET: HouseMods
        public async Task<IActionResult> Index()
        {
            return View(await _context.House.ToListAsync());
        }

        // GET: HouseMods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseMod = await _context.House
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (houseMod == null)
            {
                return NotFound();
            }

            return View(houseMod);
        }

        // GET: HouseMods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseMods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HouseId,Size,Sqft,Energy_Usage,Energy_Type")] HouseMod houseMod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(houseMod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(houseMod);
        }

        // GET: HouseMods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseMod = await _context.House.FindAsync(id);
            if (houseMod == null)
            {
                return NotFound();
            }
            return View(houseMod);
        }

        // POST: HouseMods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HouseId,Size,Sqft,Energy_Usage,Energy_Type")] HouseMod houseMod)
        {
            if (id != houseMod.HouseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(houseMod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseModExists(houseMod.HouseId))
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
            return View(houseMod);
        }

        // GET: HouseMods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseMod = await _context.House
                .FirstOrDefaultAsync(m => m.HouseId == id);
            if (houseMod == null)
            {
                return NotFound();
            }

            return View(houseMod);
        }

        // POST: HouseMods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var houseMod = await _context.House.FindAsync(id);
            _context.House.Remove(houseMod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HouseModExists(int id)
        {
            return _context.House.Any(e => e.HouseId == id);
        }
    }
}