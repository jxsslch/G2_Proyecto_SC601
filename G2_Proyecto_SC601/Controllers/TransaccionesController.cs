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
    public class TransaccionesController : Controller
    {
        private readonly SistemaEmpresarialContext _context;

        public TransaccionesController(SistemaEmpresarialContext context)
        {
            _context = context;
        }

        // GET: Transacciones
        public async Task<IActionResult> Index()
        {
            var sistemaEmpresarialContext = _context.Transacciones.Include(t => t.Cliente).Include(t => t.Lenguaje).Include(t => t.MetodoPago).Include(t => t.Moneda);
            return View(await sistemaEmpresarialContext.ToListAsync());
        }

        // GET: Transacciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Transacciones == null)
            {
                return NotFound();
            }

            var transaccione = await _context.Transacciones
                .Include(t => t.Cliente)
                .Include(t => t.Lenguaje)
                .Include(t => t.MetodoPago)
                .Include(t => t.Moneda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaccione == null)
            {
                return NotFound();
            }

            return View(transaccione);
        }

        // GET: Transacciones/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Cedula", "Cedula");
            ViewData["LenguajeId"] = new SelectList(_context.Lenguajes, "Id", "Id");
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id");
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "Id", "Id");
            return View();
        }

        // POST: Transacciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClienteId,LenguajeId,MonedaId,MetodoPagoId,Monto")] Transaccione transaccione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transaccione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Cedula", "Cedula", transaccione.ClienteId);
            ViewData["LenguajeId"] = new SelectList(_context.Lenguajes, "Id", "Id", transaccione.LenguajeId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id", transaccione.MetodoPagoId);
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "Id", "Id", transaccione.MonedaId);
            return View(transaccione);
        }

        // GET: Transacciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Transacciones == null)
            {
                return NotFound();
            }

            var transaccione = await _context.Transacciones.FindAsync(id);
            if (transaccione == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Cedula", "Cedula", transaccione.ClienteId);
            ViewData["LenguajeId"] = new SelectList(_context.Lenguajes, "Id", "Id", transaccione.LenguajeId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id", transaccione.MetodoPagoId);
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "Id", "Id", transaccione.MonedaId);
            return View(transaccione);
        }

        // POST: Transacciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClienteId,LenguajeId,MonedaId,MetodoPagoId,Monto")] Transaccione transaccione)
        {
            if (id != transaccione.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transaccione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransaccioneExists(transaccione.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Cedula", "Cedula", transaccione.ClienteId);
            ViewData["LenguajeId"] = new SelectList(_context.Lenguajes, "Id", "Id", transaccione.LenguajeId);
            ViewData["MetodoPagoId"] = new SelectList(_context.MetodoPagos, "Id", "Id", transaccione.MetodoPagoId);
            ViewData["MonedaId"] = new SelectList(_context.Moneda, "Id", "Id", transaccione.MonedaId);
            return View(transaccione);
        }

        // GET: Transacciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Transacciones == null)
            {
                return NotFound();
            }

            var transaccione = await _context.Transacciones
                .Include(t => t.Cliente)
                .Include(t => t.Lenguaje)
                .Include(t => t.MetodoPago)
                .Include(t => t.Moneda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transaccione == null)
            {
                return NotFound();
            }

            return View(transaccione);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Transacciones == null)
            {
                return Problem("Entity set 'SistemaEmpresarialContext.Transacciones'  is null.");
            }
            var transaccione = await _context.Transacciones.FindAsync(id);
            if (transaccione != null)
            {
                _context.Transacciones.Remove(transaccione);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransaccioneExists(int id)
        {
          return (_context.Transacciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
