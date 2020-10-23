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
    public class TblProductosController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblProductosController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblProductos
        public async Task<IActionResult> Index()
        {
            var dB_REPARTIDORContext = _context.TblProducto.Include(t => t.IdMarcaNavigation).Include(t => t.IdTipoProductoNavigation);
            return View(await dB_REPARTIDORContext.ToListAsync());
        }

        // GET: TblProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProducto = await _context.TblProducto
                .Include(t => t.IdMarcaNavigation)
                .Include(t => t.IdTipoProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (tblProducto == null)
            {
                return NotFound();
            }

            return View(tblProducto);
        }

        // GET: TblProductos/Create
        public IActionResult Create()
        {
            ViewData["IdMarca"] = new SelectList(_context.TblMarca, "IdMarca", "NombreMarca");
            ViewData["IdTipoProducto"] = new SelectList(_context.TblTipoProducto, "IdTipoProducto", "NombreTipoProducto");
            return View();
        }

        // POST: TblProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducto,NombreProducto,Descripcion,Precio,ActivoProducto,IdMarca,IdTipoProducto")] TblProducto tblProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMarca"] = new SelectList(_context.TblMarca, "IdMarca", "NombreMarca", tblProducto.IdMarca);
            ViewData["IdTipoProducto"] = new SelectList(_context.TblTipoProducto, "IdTipoProducto", "NombreTipoProducto", tblProducto.IdTipoProducto);
            return View(tblProducto);
        }

        // GET: TblProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProducto = await _context.TblProducto.FindAsync(id);
            if (tblProducto == null)
            {
                return NotFound();
            }
            ViewData["IdMarca"] = new SelectList(_context.TblMarca, "IdMarca", "NombreMarca", tblProducto.IdMarca);
            ViewData["IdTipoProducto"] = new SelectList(_context.TblTipoProducto, "IdTipoProducto", "NombreTipoProducto", tblProducto.IdTipoProducto);
            return View(tblProducto);
        }

        // POST: TblProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProducto,NombreProducto,Descripcion,Precio,ActivoProducto,IdMarca,IdTipoProducto")] TblProducto tblProducto)
        {
            if (id != tblProducto.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProductoExists(tblProducto.IdProducto))
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
            ViewData["IdMarca"] = new SelectList(_context.TblMarca, "IdMarca", "NombreMarca", tblProducto.IdMarca);
            ViewData["IdTipoProducto"] = new SelectList(_context.TblTipoProducto, "IdTipoProducto", "NombreTipoProducto", tblProducto.IdTipoProducto);
            return View(tblProducto);
        }

        // GET: TblProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProducto = await _context.TblProducto
                .Include(t => t.IdMarcaNavigation)
                .Include(t => t.IdTipoProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (tblProducto == null)
            {
                return NotFound();
            }

            return View(tblProducto);
        }

        // POST: TblProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProducto = await _context.TblProducto.FindAsync(id);
            _context.TblProducto.Remove(tblProducto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProductoExists(int id)
        {
            return _context.TblProducto.Any(e => e.IdProducto == id);
        }
    }
}
