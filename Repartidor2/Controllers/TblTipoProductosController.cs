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
    public class TblTipoProductosController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblTipoProductosController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblTipoProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblTipoProducto.ToListAsync());
        }

        // GET: TblTipoProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoProducto = await _context.TblTipoProducto
                .FirstOrDefaultAsync(m => m.IdTipoProducto == id);
            if (tblTipoProducto == null)
            {
                return NotFound();
            }

            return View(tblTipoProducto);
        }

        // GET: TblTipoProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblTipoProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoProducto,NombreTipoProducto,DescripcionTipoProducto,ActivoTipoProducto")] TblTipoProducto tblTipoProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTipoProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblTipoProducto);
        }

        // GET: TblTipoProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoProducto = await _context.TblTipoProducto.FindAsync(id);
            if (tblTipoProducto == null)
            {
                return NotFound();
            }
            return View(tblTipoProducto);
        }

        // POST: TblTipoProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoProducto,NombreTipoProducto,DescripcionTipoProducto,ActivoTipoProducto")] TblTipoProducto tblTipoProducto)
        {
            if (id != tblTipoProducto.IdTipoProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTipoProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTipoProductoExists(tblTipoProducto.IdTipoProducto))
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
            return View(tblTipoProducto);
        }

        // GET: TblTipoProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTipoProducto = await _context.TblTipoProducto
                .FirstOrDefaultAsync(m => m.IdTipoProducto == id);
            if (tblTipoProducto == null)
            {
                return NotFound();
            }

            return View(tblTipoProducto);
        }

        // POST: TblTipoProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTipoProducto = await _context.TblTipoProducto.FindAsync(id);
            _context.TblTipoProducto.Remove(tblTipoProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTipoProductoExists(int id)
        {
            return _context.TblTipoProducto.Any(e => e.IdTipoProducto == id);
        }
    }
}
