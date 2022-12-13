using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_medic.Models;
using System.Security.Policy;

namespace Programare_medic.Pages.Servicii
{
    public class CreateModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public CreateModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["SpitalID"] = new SelectList(_context.Set<Spital>(), "ID","DenumireSpital");
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
