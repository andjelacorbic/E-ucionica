using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace SIprojekat.Pages.OblastPages
{
    public class OblastModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public OblastModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Oblast> Oblast { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Oblast != null)
            {
                Oblast = await _context.Oblast
                .Include(o => o.Predmet).ToListAsync();
            }
        }
    }
}
