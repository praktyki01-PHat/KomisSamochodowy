﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomisSamochodowy.Data;
using KomisSamochodowy.Models;

namespace KomisSamochodowy.Controllers
{
    public class SamochodController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SamochodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Samochod
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Samochod.Include(s => s.Marka).Include(s => s.Model).Include(s => s.RodzajNadwozia).Include(s => s.RodzajPaliwa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Samochod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Samochod == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.RodzajNadwozia)
                .Include(s => s.RodzajPaliwa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // GET: Samochod/Create
        public IActionResult Create()
        {
            ViewData["MarkaId"] = new SelectList(_context.Set<Marka>(), "Id", "Id");
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Id");
            ViewData["RodzajNadwoziaId"] = new SelectList(_context.Set<RodzajNadwozia>(), "Id", "Id");
            ViewData["RodzajPaliwaId"] = new SelectList(_context.Set<RodzajPaliwa>(), "Id", "Id");
            return View();
        }

        // POST: Samochod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kolor,PojemnoscSilnika,Przebieg,NumerVIN,Cena,MarkaId,ModelId,RodzajNadwoziaId,RodzajPaliwaId")] Samochod samochod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(samochod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MarkaId"] = new SelectList(_context.Set<Marka>(), "Id", "Id", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Id", samochod.ModelId);
            ViewData["RodzajNadwoziaId"] = new SelectList(_context.Set<RodzajNadwozia>(), "Id", "Id", samochod.RodzajNadwoziaId);
            ViewData["RodzajPaliwaId"] = new SelectList(_context.Set<RodzajPaliwa>(), "Id", "Id", samochod.RodzajPaliwaId);
            return View(samochod);
        }

        // GET: Samochod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Samochod == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod.FindAsync(id);
            if (samochod == null)
            {
                return NotFound();
            }
            ViewData["MarkaId"] = new SelectList(_context.Set<Marka>(), "Id", "Nazwa", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Nazwa", samochod.ModelId);
            ViewData["RodzajNadwoziaId"] = new SelectList(_context.Set<RodzajNadwozia>(), "Id", "Nazwa", samochod.RodzajNadwoziaId);
            ViewData["RodzajPaliwaId"] = new SelectList(_context.Set<RodzajPaliwa>(), "Id", "Nazwa", samochod.RodzajPaliwaId);
            return View(samochod);
        }

        // POST: Samochod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kolor,PojemnoscSilnika,Przebieg,NumerVIN,Cena,MarkaId,ModelId,RodzajNadwoziaId,RodzajPaliwaId")] Samochod samochod)
        {
            if (id != samochod.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(samochod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SamochodExists(samochod.Id))
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
            ViewData["MarkaId"] = new SelectList(_context.Set<Marka>(), "Id", "Nazwa", samochod.MarkaId);
            ViewData["ModelId"] = new SelectList(_context.Set<Model>(), "Id", "Nazwa", samochod.ModelId);
            ViewData["RodzajNadwoziaId"] = new SelectList(_context.Set<RodzajNadwozia>(), "Id", "Nazwa", samochod.RodzajNadwoziaId);
            ViewData["RodzajPaliwaId"] = new SelectList(_context.Set<RodzajPaliwa>(), "Id", "Nazwa", samochod.RodzajPaliwaId);
            return View(samochod);
        }

        // GET: Samochod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Samochod == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochod
                .Include(s => s.Marka)
                .Include(s => s.Model)
                .Include(s => s.RodzajNadwozia)
                .Include(s => s.RodzajPaliwa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (samochod == null)
            {
                return NotFound();
            }

            return View(samochod);
        }

        // POST: Samochod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Samochod == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Samochod'  is null.");
            }
            var samochod = await _context.Samochod.FindAsync(id);
            if (samochod != null)
            {
                _context.Samochod.Remove(samochod);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SamochodExists(int id)
        {
          return (_context.Samochod?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
