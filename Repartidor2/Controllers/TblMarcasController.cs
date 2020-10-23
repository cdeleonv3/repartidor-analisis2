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
    public class TblMarcasController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblMarcasController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblMarcas
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblMarca.ToListAsync());
        }

        // GET: TblMarcas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMarca = await _context.TblMarca
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (tblMarca == null)
            {
                return NotFound();
            }

            return View(tblMarca);
        }

        // GET: TblMarcas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblMarcas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMarca,NombreMarca,DescripcionMarca,ActivoMarca")] TblMarca tblMarca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblMarca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblMarca);
        }

        // GET: TblMarcas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMarca = await _context.TblMarca.FindAsync(id);
            if (tblMarca == null)
            {
                return NotFound();
            }
            return View(tblMarca);
        }

        // POST: TblMarcas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMarca,NombreMarca,DescripcionMarca,ActivoMarca")] TblMarca tblMarca)
        {
            if (id != tblMarca.IdMarca)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblMarca);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblMarcaExists(tblMarca.IdMarca))
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
            return View(tblMarca);
        }

        // GET: TblMarcas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblMarca = await _context.TblMarca
                .FirstOrDefaultAsync(m => m.IdMarca == id);
            if (tblMarca == null)
            {
                return NotFound();
            }

            return View(tblMarca);
        }

        // POST: TblMarcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblMarca = await _context.TblMarca.FindAsync(id);
            _context.TblMarca.Remove(tblMarca);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblMarcaExists(int id)
        {
            return _context.TblMarca.Any(e => e.IdMarca == id);
        }
    }
}
