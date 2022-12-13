using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Models;

namespace Programare_medic.Pages.Servicii
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public DetailsModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }
            else
            {
                Serviciu = serviciu;
            }
            return Page();
        }
    }
}
