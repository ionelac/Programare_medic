using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Data;
using Programare_medic.Models;

namespace Programare_medic.Pages.Spitale
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public DetailsModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

      public Spital Spital { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Spital == null)
            {
                return NotFound();
            }

            var spital = await _context.Spital.FirstOrDefaultAsync(m => m.ID == id);
            if (spital == null)
            {
                return NotFound();
            }
            else 
            {
                Spital = spital;
            }
            return Page();
        }
    }
}
