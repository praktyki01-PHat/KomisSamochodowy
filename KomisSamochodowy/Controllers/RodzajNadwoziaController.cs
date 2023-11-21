using System;
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
    public class RodzajNadwoziaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RodzajNadwoziaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RodzajNadwozia
        public async Task<IActionResult> Index()
        {
              return _context.RodzajNadwozia != null ? 
                          View(await _context.RodzajNadwozia.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.RodzajNadwozia'  is null.");
        }

        // GET: RodzajNadwozia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RodzajNadwozia == null)
            {
                return NotFound();
            }

            var rodzajNadwozia = await _context.RodzajNadwozia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rodzajNadwozia == null)
            {
                return NotFound();
            }

            return View(rodzajNadwozia);
        }

        // GET: RodzajNadwozia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RodzajNadwozia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nazwa")] RodzajNadwozia rodzajNadwozia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rodzajNadwozia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rodzajNadwozia);
        }

        // GET: RodzajNadwozia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RodzajNadwozia == null)
            {
                return NotFound();
            }

            var rodzajNadwozia = await _context.RodzajNadwozia.FindAsync(id);
            if (rodzajNadwozia == null)
            {
                return NotFound();
            }
            return View(rodzajNadwozia);
        }

        // POST: RodzajNadwozia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nazwa")] RodzajNadwozia rodzajNadwozia)
        {
            if (id != rodzajNadwozia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rodzajNadwozia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RodzajNadwoziaExists(rodzajNadwozia.Id))
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
            return View(rodzajNadwozia);
        }

        // GET: RodzajNadwozia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RodzajNadwozia == null)
            {
                return NotFound();
            }

            var rodzajNadwozia = await _context.RodzajNadwozia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rodzajNadwozia == null)
            {
                return NotFound();
            }

            return View(rodzajNadwozia);
        }

        // POST: RodzajNadwozia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RodzajNadwozia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.RodzajNadwozia'  is null.");
            }
            var rodzajNadwozia = await _context.RodzajNadwozia.FindAsync(id);
            if (rodzajNadwozia != null)
            {
                _context.RodzajNadwozia.Remove(rodzajNadwozia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RodzajNadwoziaExists(int id)
        {
          return (_context.RodzajNadwozia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
