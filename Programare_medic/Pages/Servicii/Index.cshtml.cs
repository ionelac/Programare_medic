using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Models;

namespace Programare_medic.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public IndexModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Serviciu != null)
            {
                Serviciu = await _context.Serviciu.Include(b=>b.Spital)
                    .ToListAsync();
            }
        }
    }
}
