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
    public class IndexModel : PageModel
    {
        private readonly Repartidor.Models.DB_REPARTIDORContext _context;

        public IndexModel(Repartidor.Models.DB_REPARTIDORContext context)
        {
            _context = context;
        }

        public IList<TblCliente> TblCliente { get;set; }

        public async Task OnGetAsync()
        {
            TblCliente = await _context.TblCliente.ToListAsync();
        }
    }
}
