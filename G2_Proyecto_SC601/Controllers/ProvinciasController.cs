using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using G2_Proyecto_SC601.Models;

namespace G2_Proyecto_SC601.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly SistemaEmpresarialContext _context;

        public ProvinciasController(SistemaEmpresarialContext context)
        {
            _context = context;
        }

        // GET: Provincias
        public async Task<IActionResult> Index()
        {
              return _context.Provincia != null ? 
                          View(await _context.Provincia.ToListAsync()) :
                          Problem("Entity set 'SistemaEmpresarialContext.Provincia'  is null.");
        }

        // GET: Provincias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Provincia == null)
            {
                return NotFound();
            }

            var provincium = await _context.Provincia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincium == null)
            {
                return NotFound();
            }

            return View(provincium);
        }

        // GET: Provincias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Provincias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] Provincium provincium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(provincium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provincium);
        }

        // GET: Provincias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Provincia == null)
            {
                return NotFound();
            }

            var provincium = await _context.Provincia.FindAsync(id);
            if (provincium == null)
            {
                return NotFound();
            }
            return View(provincium);
        }

        // POST: Provincias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] Provincium provincium)
        {
            if (id != provincium.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(provincium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProvinciumExists(provincium.Id))
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
            return View(provincium);
        }

        // GET: Provincias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Provincia == null)
            {
                return NotFound();
            }

            var provincium = await _context.Provincia
                .FirstOrDefaultAsync(m => m.Id == id);
            if (provincium == null)
            {
                return NotFound();
            }

            return View(provincium);
        }

        // POST: Provincias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Provincia == null)
            {
                return Problem("Entity set 'SistemaEmpresarialContext.Provincia'  is null.");
            }
            var provincium = await _context.Provincia.FindAsync(id);
            if (provincium != null)
            {
                _context.Provincia.Remove(provincium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProvinciumExists(int id)
        {
          return (_context.Provincia?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
