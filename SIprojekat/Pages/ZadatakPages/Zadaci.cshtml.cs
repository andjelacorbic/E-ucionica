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
    public class ZadatakModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;
        public string SearchText { get; set; }

        public ZadatakModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Zadatak> Zadatak { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Zadatak != null)
            {
                Zadatak = await _context.Zadatak
                .Include(z => z.NivoTezine)
                .Include(z => z.Oblast)
                .Include(z => z.Predmet).ToListAsync();
            }
        }

        public async void OnPost()
        {
            if (SearchText == null)
            {
                Zadatak = await _context.Zadatak.ToListAsync();
            }
            else
            {
                Zadatak = await _context.Zadatak
                    .Include(z => z.NivoTezine)
                    .Include(z => z.Oblast)
                    .Include(z => z.Predmet)
                    .Where(z => EF.Functions.Like(z.Oblast.NazivOblasti, $"%{SearchText}%"))
                    .ToListAsync();
            }
        }
    }
}
