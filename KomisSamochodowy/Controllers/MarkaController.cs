using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KomisSamochodowy.Data;
using KomisSamochodowy.Models;
using Microsoft.AspNetCore.Authorization;

namespace KomisSamochodowy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MarkaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MarkaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Marka
        public async Task<IActionResult> Index()
        {
              return _context.Marka != null ? 
                          View(await _context.Marka.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Marka'  is null.");
        }

        // GET: Marka/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Marka == null)
            {
                return NotFound();
            }

            var marka = await _context.Marka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // GET: Marka/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Marka/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] Marka marka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(marka);
        }

        // GET: Marka/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Marka == null)
            {
                return NotFound();
            }

            var marka = await _context.Marka.FindAsync(id);
            if (marka == null)
            {
                return NotFound();
            }
            return View(marka);
        }

        // POST: Marka/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] Marka marka)
        {
            if (id != marka.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(marka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MarkaExists(marka.Id))
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
            return View(marka);
        }

        // GET: Marka/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Marka == null)
            {
                return NotFound();
            }

            var marka = await _context.Marka
                .FirstOrDefaultAsync(m => m.Id == id);
            if (marka == null)
            {
                return NotFound();
            }

            return View(marka);
        }

        // POST: Marka/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Marka == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Marka'  is null.");
            }
            var marka = await _context.Marka.FindAsync(id);
            if (marka != null)
            {
                _context.Marka.Remove(marka);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MarkaExists(int id)
        {
          return (_context.Marka?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
