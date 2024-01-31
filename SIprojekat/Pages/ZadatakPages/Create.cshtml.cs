using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataBaseContext;
using DatabaseEntityLib;
using Microsoft.Extensions.Hosting;

namespace SIprojekat.Pages.ZadatakPages
{
    public class CreateModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;
        private IWebHostEnvironment _environment;

        public CreateModel(DataBaseContext.DB_Context_Class context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
        ViewData["TezinaID"] = new SelectList(_context.NivoTezine, "ID", "Tezina");
        ViewData["OblastID"] = new SelectList(_context.Oblast, "ID", "NazivOblasti");
        ViewData["PredmetID"] = new SelectList(_context.Predmet, "ID", "Naziv");
            return Page();
        }

        [BindProperty]
        public Zadatak Zadatak { get; set; } = default!;

        [BindProperty]
        public IFormFile Upload { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Zadatak == null || Zadatak == null)
            {
                return Page();
            }

            var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\images", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);

                Zadatak.Image = Upload.FileName;
            }

            _context.Zadatak.Add(Zadatak);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Zadaci");
        }
    }
}
