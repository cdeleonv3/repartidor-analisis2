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
    public class TblTarjetasController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblTarjetasController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblTarjetas
        public async Task<IActionResult> Index()
        {
            var dB_REPARTIDORContext = _context.TblTarjeta.Include(t => t.IdClienteNavigation);
            return View(await dB_REPARTIDORContext.ToListAsync());
        }

        // GET: TblTarjetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTarjeta = await _context.TblTarjeta
                .Include(t => t.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdTarjeta == id);
            if (tblTarjeta == null)
            {
                return NotFound();
            }

            return View(tblTarjeta);
        }

        // GET: TblTarjetas/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.TblCliente, "IdCliente", "IdCliente");
            return View();
        }

        // POST: TblTarjetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTarjeta,IdCliente,NombreTarjeta,NumeroTarjeta,FechaVenceTarjeta,ProveedorTarjeta,CvvTarjeta,ActivoTarjeta")] TblTarjeta tblTarjeta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblTarjeta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.TblCliente, "IdCliente", "IdCliente", tblTarjeta.IdCliente);
            return View(tblTarjeta);
        }

        // GET: TblTarjetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTarjeta = await _context.TblTarjeta.FindAsync(id);
            if (tblTarjeta == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.TblCliente, "IdCliente", "IdCliente", tblTarjeta.IdCliente);
            return View(tblTarjeta);
        }

        // POST: TblTarjetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTarjeta,IdCliente,NombreTarjeta,NumeroTarjeta,FechaVenceTarjeta,ProveedorTarjeta,CvvTarjeta,ActivoTarjeta")] TblTarjeta tblTarjeta)
        {
            if (id != tblTarjeta.IdTarjeta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblTarjeta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblTarjetaExists(tblTarjeta.IdTarjeta))
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
            ViewData["IdCliente"] = new SelectList(_context.TblCliente, "IdCliente", "IdCliente", tblTarjeta.IdCliente);
            return View(tblTarjeta);
        }

        // GET: TblTarjetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblTarjeta = await _context.TblTarjeta
                .Include(t => t.IdClienteNavigation)
                .FirstOrDefaultAsync(m => m.IdTarjeta == id);
            if (tblTarjeta == null)
            {
                return NotFound();
            }

            return View(tblTarjeta);
        }

        // POST: TblTarjetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblTarjeta = await _context.TblTarjeta.FindAsync(id);
            _context.TblTarjeta.Remove(tblTarjeta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblTarjetaExists(int id)
        {
            return _context.TblTarjeta.Any(e => e.IdTarjeta == id);
        }
    }
}
