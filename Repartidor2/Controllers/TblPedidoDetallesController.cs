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
    public class TblPedidoDetallesController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblPedidoDetallesController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblPedidoDetalles
        public async Task<IActionResult> Index()
        {
            var dB_REPARTIDORContext = _context.TblPedidoDetalle.Include(t => t.IdPedidoNavigation).Include(t => t.IdProductoNavigation);
            return View(await dB_REPARTIDORContext.ToListAsync());
        }

        // GET: TblPedidoDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPedidoDetalle = await _context.TblPedidoDetalle
                .Include(t => t.IdPedidoNavigation)
                .Include(t => t.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedidoDetalle == id);
            if (tblPedidoDetalle == null)
            {
                return NotFound();
            }

            return View(tblPedidoDetalle);
        }

        // GET: TblPedidoDetalles/Create
        public IActionResult Create()
        {
            ViewData["IdPedido"] = new SelectList(_context.TblPedido, "IdPedido", "DireccionPedido");
            ViewData["IdProducto"] = new SelectList(_context.TblProducto, "IdProducto", "NombreProducto");
            return View();
        }

        // POST: TblPedidoDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedidoDetalle,CantidadPedidoDetalle,PrecioPedidoDetalle,TotalPedidoDetalle,ActivoPedidoDetalle,IdPedido,IdProducto")] TblPedidoDetalle tblPedidoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPedidoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPedido"] = new SelectList(_context.TblPedido, "IdPedido", "DireccionPedido", tblPedidoDetalle.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.TblProducto, "IdProducto", "NombreProducto", tblPedidoDetalle.IdProducto);
            return View(tblPedidoDetalle);
        }

        // GET: TblPedidoDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPedidoDetalle = await _context.TblPedidoDetalle.FindAsync(id);
            if (tblPedidoDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdPedido"] = new SelectList(_context.TblPedido, "IdPedido", "DireccionPedido", tblPedidoDetalle.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.TblProducto, "IdProducto", "NombreProducto", tblPedidoDetalle.IdProducto);
            return View(tblPedidoDetalle);
        }

        // POST: TblPedidoDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedidoDetalle,CantidadPedidoDetalle,PrecioPedidoDetalle,TotalPedidoDetalle,ActivoPedidoDetalle,IdPedido,IdProducto")] TblPedidoDetalle tblPedidoDetalle)
        {
            if (id != tblPedidoDetalle.IdPedidoDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPedidoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPedidoDetalleExists(tblPedidoDetalle.IdPedidoDetalle))
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
            ViewData["IdPedido"] = new SelectList(_context.TblPedido, "IdPedido", "DireccionPedido", tblPedidoDetalle.IdPedido);
            ViewData["IdProducto"] = new SelectList(_context.TblProducto, "IdProducto", "NombreProducto", tblPedidoDetalle.IdProducto);
            return View(tblPedidoDetalle);
        }

        // GET: TblPedidoDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPedidoDetalle = await _context.TblPedidoDetalle
                .Include(t => t.IdPedidoNavigation)
                .Include(t => t.IdProductoNavigation)
                .FirstOrDefaultAsync(m => m.IdPedidoDetalle == id);
            if (tblPedidoDetalle == null)
            {
                return NotFound();
            }

            return View(tblPedidoDetalle);
        }

        // POST: TblPedidoDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPedidoDetalle = await _context.TblPedidoDetalle.FindAsync(id);
            _context.TblPedidoDetalle.Remove(tblPedidoDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPedidoDetalleExists(int id)
        {
            return _context.TblPedidoDetalle.Any(e => e.IdPedidoDetalle == id);
        }
    }
}
