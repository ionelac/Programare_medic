using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Data;
using Programare_medic.Models;

namespace Programare_medic.Pages.Spitale
{
    public class EditModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public EditModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Spital Spital { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Spital == null)
            {
                return NotFound();
            }

            var spital =  await _context.Spital.FirstOrDefaultAsync(m => m.ID == id);
            if (spital == null)
            {
                return NotFound();
            }
            Spital = spital;
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

            _context.Attach(Spital).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpitalExists(Spital.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SpitalExists(int id)
        {
          return _context.Spital.Any(e => e.ID == id);
        }
    }
}
