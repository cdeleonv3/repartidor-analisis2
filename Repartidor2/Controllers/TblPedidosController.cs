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
    public class TblPedidosController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblPedidosController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblPedidos
        public async Task<IActionResult> Index()
        {
            var dB_REPARTIDORContext = _context.TblPedido.Include(t => t.Id).Include(t => t.IdEstadoNavigation).Include(t => t.IdRestauranteNavigation);
            return View(await dB_REPARTIDORContext.ToListAsync());
        }

        // GET: TblPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPedido = await _context.TblPedido
                .Include(t => t.Id)
                .Include(t => t.IdEstadoNavigation)
                .Include(t => t.IdRestauranteNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (tblPedido == null)
            {
                return NotFound();
            }

            return View(tblPedido);
        }

        // GET: TblPedidos/Create
        public IActionResult Create()
        {
            ViewData["IdTarjeta"] = new SelectList(_context.TblTarjeta, "IdTarjeta", "NombreTarjeta");
            ViewData["IdEstado"] = new SelectList(_context.TblEstado, "IdEstado", "NombreEstado");
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante");
            return View();
        }

        // POST: TblPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPedido,FechaPedido,HoraPedido,HoraEntrega,DireccionPedido,DetalleDireccion,Total,ActivoPedido,IdTarjeta,IdCliente,IdRestaurante,IdEstado")] TblPedido tblPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTarjeta"] = new SelectList(_context.TblTarjeta, "IdTarjeta", "NombreTarjeta", tblPedido.IdTarjeta);
            ViewData["IdEstado"] = new SelectList(_context.TblEstado, "IdEstado", "NombreEstado", tblPedido.IdEstado);
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante", tblPedido.IdRestaurante);
            return View(tblPedido);
        }

        // GET: TblPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPedido = await _context.TblPedido.FindAsync(id);
            if (tblPedido == null)
            {
                return NotFound();
            }
            ViewData["IdTarjeta"] = new SelectList(_context.TblTarjeta, "IdTarjeta", "NombreTarjeta", tblPedido.IdTarjeta);
            ViewData["IdEstado"] = new SelectList(_context.TblEstado, "IdEstado", "NombreEstado", tblPedido.IdEstado);
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante", tblPedido.IdRestaurante);
            return View(tblPedido);
        }

        // POST: TblPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,FechaPedido,HoraPedido,HoraEntrega,DireccionPedido,DetalleDireccion,Total,ActivoPedido,IdTarjeta,IdCliente,IdRestaurante,IdEstado")] TblPedido tblPedido)
        {
            if (id != tblPedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblPedidoExists(tblPedido.IdPedido))
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
            ViewData["IdTarjeta"] = new SelectList(_context.TblTarjeta, "IdTarjeta", "NombreTarjeta", tblPedido.IdTarjeta);
            ViewData["IdEstado"] = new SelectList(_context.TblEstado, "IdEstado", "NombreEstado", tblPedido.IdEstado);
            ViewData["IdRestaurante"] = new SelectList(_context.TblRestaurante, "IdRestaurante", "DireccionRestaurante", tblPedido.IdRestaurante);
            return View(tblPedido);
        }

        // GET: TblPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblPedido = await _context.TblPedido
                .Include(t => t.Id)
                .Include(t => t.IdEstadoNavigation)
                .Include(t => t.IdRestauranteNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (tblPedido == null)
            {
                return NotFound();
            }

            return View(tblPedido);
        }

        // POST: TblPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblPedido = await _context.TblPedido.FindAsync(id);
            _context.TblPedido.Remove(tblPedido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblPedidoExists(int id)
        {
            return _context.TblPedido.Any(e => e.IdPedido == id);
        }
    }
}
