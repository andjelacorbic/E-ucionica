using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace SIprojekat.Pages.NivoTezinePages
{
    public class NivoTezineModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public NivoTezineModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IList<NivoTezine> NivoTezine { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.NivoTezine != null)
            {
                NivoTezine = await _context.NivoTezine.ToListAsync();
            }
        }
    }
}
