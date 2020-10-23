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
    public class TblEstadosController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblEstadosController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblEstados
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblEstado.ToListAsync());
        }

        // GET: TblEstados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEstado = await _context.TblEstado
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (tblEstado == null)
            {
                return NotFound();
            }

            return View(tblEstado);
        }

        // GET: TblEstados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblEstados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,NombreEstado,DescripcionEstado,ActivoEstado")] TblEstado tblEstado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEstado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEstado);
        }

        // GET: TblEstados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEstado = await _context.TblEstado.FindAsync(id);
            if (tblEstado == null)
            {
                return NotFound();
            }
            return View(tblEstado);
        }

        // POST: TblEstados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,NombreEstado,DescripcionEstado,ActivoEstado")] TblEstado tblEstado)
        {
            if (id != tblEstado.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEstado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblEstadoExists(tblEstado.IdEstado))
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
            return View(tblEstado);
        }

        // GET: TblEstados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblEstado = await _context.TblEstado
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (tblEstado == null)
            {
                return NotFound();
            }

            return View(tblEstado);
        }

        // POST: TblEstados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblEstado = await _context.TblEstado.FindAsync(id);
            _context.TblEstado.Remove(tblEstado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblEstadoExists(int id)
        {
            return _context.TblEstado.Any(e => e.IdEstado == id);
        }
    }
}
