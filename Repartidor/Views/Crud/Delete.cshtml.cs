using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repartidor.Models;

namespace Repartidor.Views.Crud
{
    public class DeleteModel : PageModel
    {
        private readonly Repartidor.Models.DB_REPARTIDORContext _context;

        public DeleteModel(Repartidor.Models.DB_REPARTIDORContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            TblCliente = await _context.TblCliente.FindAsync(id);

            if (TblCliente != null)
            {
                _context.TblCliente.Remove(TblCliente);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
