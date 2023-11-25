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
    public class ClientesController : Controller
    {
        private readonly SistemaEmpresarialContext _context;

        public ClientesController(SistemaEmpresarialContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var sistemaEmpresarialContext = _context.Clientes.Include(c => c.Canton).Include(c => c.Empresa).Include(c => c.Provincia);
            return View(await sistemaEmpresarialContext.ToListAsync());
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Canton)
                .Include(c => c.Empresa)
                .Include(c => c.Provincia)
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            ViewData["CantonId"] = new SelectList(_context.Cantons, "Id", "Id");
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id");
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Id");
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Cedula,Nombre,Email,NumTelefono,EmpresaId,ProvinciaId,CantonId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CantonId"] = new SelectList(_context.Cantons, "Id", "Id", cliente.CantonId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id", cliente.EmpresaId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Id", cliente.ProvinciaId);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            ViewData["CantonId"] = new SelectList(_context.Cantons, "Id", "Id", cliente.CantonId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id", cliente.EmpresaId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Id", cliente.ProvinciaId);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Cedula,Nombre,Email,NumTelefono,EmpresaId,ProvinciaId,CantonId")] Cliente cliente)
        {
            if (id != cliente.Cedula)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Cedula))
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
            ViewData["CantonId"] = new SelectList(_context.Cantons, "Id", "Id", cliente.CantonId);
            ViewData["EmpresaId"] = new SelectList(_context.Empresas, "Id", "Id", cliente.EmpresaId);
            ViewData["ProvinciaId"] = new SelectList(_context.Provincia, "Id", "Id", cliente.ProvinciaId);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Canton)
                .Include(c => c.Empresa)
                .Include(c => c.Provincia)
                .FirstOrDefaultAsync(m => m.Cedula == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Clientes == null)
            {
                return Problem("Entity set 'SistemaEmpresarialContext.Clientes'  is null.");
            }
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Cedula == id)).GetValueOrDefault();
        }
    }
}
