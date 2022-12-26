using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Data;
using Programare_medic.Models;

namespace Programare_medic.Pages.Sectii
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public DeleteModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Sectie Sectie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sectie == null)
            {
                return NotFound();
            }

            var sectie = await _context.Sectie.FirstOrDefaultAsync(m => m.ID == id);

            if (sectie == null)
            {
                return NotFound();
            }
            else 
            {
                Sectie = sectie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sectie == null)
            {
                return NotFound();
            }
            var sectie = await _context.Sectie.FindAsync(id);

            if (sectie != null)
            {
                Sectie = sectie;
                _context.Sectie.Remove(Sectie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
