using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repartidor2.Models;

namespace Repartidor2.Controllers
{
    public class TblEmpleadosController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblEmpleadosController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblEmpleados
        public async Task<IActionResult> Index()
        {
            var dB_REPARTIDORContext = _context.TblEmpleado.Include(t => t.IdRestauranteNavigation).Include(t => t.IdTipoEmpleadoNavigation);
            return View(await dB_REPARTIDORContext.ToListAsync());
        }

        // GET: TblEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpleado = await _context.TblEmpleado
                .Include(t => t.IdRestauranteNavigation)
                .Include(t => t.IdTipoEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (tblEmpleado == null)
            {
                return NotFound();
            }

            return View(tblEmpleado);
        }

        // GET: TblEmpleados/Create
        public IActionResult Create()
        {
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante");
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TblTipoEmpleado, "IdTipoEmpleado", "NombreTipoEmpleado");
            return View();
        }

        // POST: TblEmpleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEmpleado,NombreEmpleado,ApellidoEmpleado,TelefonoEmpleado,DireccionEmpleado,ActivoEmpleado,IdRestaurante,IdTipoEmpleado")] TblEmpleado tblEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante", tblEmpleado.IdRestaurante);
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TblTipoEmpleado, "IdTipoEmpleado", "NombreTipoEmpleado", tblEmpleado.IdTipoEmpleado);
            return View(tblEmpleado);
        }

        // GET: TblEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpleado = await _context.TblEmpleado.FindAsync(id);
            if (tblEmpleado == null)
            {
                return NotFound();
            }
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante", tblEmpleado.IdRestaurante);
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TblTipoEmpleado, "IdTipoEmpleado", "NombreTipoEmpleado", tblEmpleado.IdTipoEmpleado);
            return View(tblEmpleado);
        }

        // POST: TblEmpleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEmpleado,NombreEmpleado,ApellidoEmpleado,TelefonoEmpleado,DireccionEmpleado,ActivoEmpleado,IdRestaurante,IdTipoEmpleado")] TblEmpleado tblEmpleado)
        {
            if (id != tblEmpleado.IdEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEmpleadoExists(tblEmpleado.IdEmpleado))
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
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante", tblEmpleado.IdRestaurante);
            ViewData["IdTipoEmpleado"] = new SelectList(_context.TblTipoEmpleado, "IdTipoEmpleado", "NombreTipoEmpleado", tblEmpleado.IdTipoEmpleado);
            return View(tblEmpleado);
        }

        // GET: TblEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEmpleado = await _context.TblEmpleado
                .Include(t => t.IdRestauranteNavigation)
                .Include(t => t.IdTipoEmpleadoNavigation)
                .FirstOrDefaultAsync(m => m.IdEmpleado == id);
            if (tblEmpleado == null)
            {
                return NotFound();
            }

            return View(tblEmpleado);
        }

        // POST: TblEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblEmpleado = await _context.TblEmpleado.FindAsync(id);
            _context.TblEmpleado.Remove(tblEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEmpleadoExists(int id)
        {
            return _context.TblEmpleado.Any(e => e.IdEmpleado == id);
        }
    }
}
