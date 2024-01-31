using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;

namespace SIprojekat.Pages.ZadatakPages
{
    public class EditModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;
        private IWebHostEnvironment _environment;

        public EditModel(DataBaseContext.DB_Context_Class context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Zadatak Zadatak { get; set; } = default!;

        [BindProperty]
        public IFormFile Upload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zadatak == null)
            {
                return NotFound();
            }

            var zadatak =  await _context.Zadatak.FirstOrDefaultAsync(m => m.ID == id);
            if (zadatak == null)
            {
                return NotFound();
            }
            Zadatak = zadatak;
           ViewData["TezinaID"] = new SelectList(_context.NivoTezine, "ID", "Tezina");
           ViewData["OblastID"] = new SelectList(_context.Oblast, "ID", "NazivOblasti");
           ViewData["PredmetID"] = new SelectList(_context.Predmet, "ID", "Naziv");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\images", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);

                Zadatak.Image = Upload.FileName;
            }
            

            _context.Attach(Zadatak).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZadatakExists(Zadatak.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Zadaci");
        }

        private bool ZadatakExists(int id)
        {
          return (_context.Zadatak?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
