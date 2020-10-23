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
    public class TblTipoEmpleadosController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblTipoEmpleadosController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblTipoEmpleados
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTipoEmpleado.ToListAsync());
        }

        // GET: TblTipoEmpleados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoEmpleado = await _context.TblTipoEmpleado
                .FirstOrDefaultAsync(m => m.IdTipoEmpleado == id);
            if (tblTipoEmpleado == null)
            {
                return NotFound();
            }

            return View(tblTipoEmpleado);
        }

        // GET: TblTipoEmpleados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblTipoEmpleados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoEmpleado,NombreTipoEmpleado,DescripcionTipoEmpleado,ActivoTipoEmpleado")] TblTipoEmpleado tblTipoEmpleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTipoEmpleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTipoEmpleado);
        }

        // GET: TblTipoEmpleados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoEmpleado = await _context.TblTipoEmpleado.FindAsync(id);
            if (tblTipoEmpleado == null)
            {
                return NotFound();
            }
            return View(tblTipoEmpleado);
        }

        // POST: TblTipoEmpleados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoEmpleado,NombreTipoEmpleado,DescripcionTipoEmpleado,ActivoTipoEmpleado")] TblTipoEmpleado tblTipoEmpleado)
        {
            if (id != tblTipoEmpleado.IdTipoEmpleado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTipoEmpleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTipoEmpleadoExists(tblTipoEmpleado.IdTipoEmpleado))
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
            return View(tblTipoEmpleado);
        }

        // GET: TblTipoEmpleados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoEmpleado = await _context.TblTipoEmpleado
                .FirstOrDefaultAsync(m => m.IdTipoEmpleado == id);
            if (tblTipoEmpleado == null)
            {
                return NotFound();
            }

            return View(tblTipoEmpleado);
        }

        // POST: TblTipoEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTipoEmpleado = await _context.TblTipoEmpleado.FindAsync(id);
            _context.TblTipoEmpleado.Remove(tblTipoEmpleado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTipoEmpleadoExists(int id)
        {
            return _context.TblTipoEmpleado.Any(e => e.IdTipoEmpleado == id);
        }
    }
}
