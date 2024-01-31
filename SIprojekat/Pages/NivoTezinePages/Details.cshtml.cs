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
    public class DetailsModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public DetailsModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

      public NivoTezine NivoTezine { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NivoTezine == null)
            {
                return NotFound();
            }

            var nivotezine = await _context.NivoTezine.FirstOrDefaultAsync(m => m.ID == id);
            if (nivotezine == null)
            {
                return NotFound();
            }
            else 
            {
                NivoTezine = nivotezine;
            }
            return Page();
        }
    }
}
