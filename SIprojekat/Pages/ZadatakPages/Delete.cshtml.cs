using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace SIprojekat.Pages.ZadatakPages
{
    public class DeleteModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public DeleteModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        [BindProperty]
      public Zadatak Zadatak { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zadatak == null)
            {
                return NotFound();
            }

            var zadatak = await _context.Zadatak.FirstOrDefaultAsync(m => m.ID == id);

            if (zadatak == null)
            {
                return NotFound();
            }
            else 
            {
                Zadatak = zadatak;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zadatak == null)
            {
                return NotFound();
            }
            var zadatak = await _context.Zadatak.FindAsync(id);

            if (zadatak != null)
            {
                Zadatak = zadatak;
                _context.Zadatak.Remove(Zadatak);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Zadaci");
        }
    }
}
