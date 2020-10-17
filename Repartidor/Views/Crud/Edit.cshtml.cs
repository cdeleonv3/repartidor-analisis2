using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repartidor.Models;

namespace Repartidor.Views.Crud
{
    public class EditModel : PageModel
    {
        private readonly Repartidor.Models.DB_REPARTIDORContext _context;

        public EditModel(Repartidor.Models.DB_REPARTIDORContext context)
        {
            _context = context;
        }

        [BindProperty]
        public TblCliente TblCliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblCliente = await _context.TblCliente.FirstOrDefaultAsync(m => m.IdCliente == id);

            if (TblCliente == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(TblCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblClienteExists(TblCliente.IdCliente))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TblClienteExists(int id)
        {
            return _context.TblCliente.Any(e => e.IdCliente == id);
        }
    }
}
