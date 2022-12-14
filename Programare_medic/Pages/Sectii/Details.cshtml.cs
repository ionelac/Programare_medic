using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Data;
using Programare_medic.Models;

namespace Programare_medic.Pages.Sectii
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public DetailsModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

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
    }
}
