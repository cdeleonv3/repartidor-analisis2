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
    public class TblRestaurantesController : Controller
    {
        private readonly DB_REPARTIDORContext _context;

        public TblRestaurantesController(DB_REPARTIDORContext context)
        {
            _context = context;
        }

        // GET: TblRestaurantes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblRestaurante.ToListAsync());
        }

        // GET: TblRestaurantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRestaurante = await _context.TblRestaurante
                .FirstOrDefaultAsync(m => m.IdRestaurante == id);
            if (tblRestaurante == null)
            {
                return NotFound();
            }

            return View(tblRestaurante);
        }

        // GET: TblRestaurantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblRestaurantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRestaurante,NombreRestaurante,DireccionRestaurante,Telefono,ActivoRestaurante")] TblRestaurante tblRestaurante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblRestaurante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblRestaurante);
        }

        // GET: TblRestaurantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRestaurante = await _context.TblRestaurante.FindAsync(id);
            if (tblRestaurante == null)
            {
                return NotFound();
            }
            return View(tblRestaurante);
        }

        // POST: TblRestaurantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRestaurante,NombreRestaurante,DireccionRestaurante,Telefono,ActivoRestaurante")] TblRestaurante tblRestaurante)
        {
            if (id != tblRestaurante.IdRestaurante)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblRestaurante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblRestauranteExists(tblRestaurante.IdRestaurante))
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
            return View(tblRestaurante);
        }

        // GET: TblRestaurantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblRestaurante = await _context.TblRestaurante
                .FirstOrDefaultAsync(m => m.IdRestaurante == id);
            if (tblRestaurante == null)
            {
                return NotFound();
            }

            return View(tblRestaurante);
        }

        // POST: TblRestaurantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblRestaurante = await _context.TblRestaurante.FindAsync(id);
            _context.TblRestaurante.Remove(tblRestaurante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblRestauranteExists(int id)
        {
            return _context.TblRestaurante.Any(e => e.IdRestaurante == id);
        }
    }
}
