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
        public ServiciuData ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int SectieID { get; set; }

        public async Task OnGetAsync(int? id, int? sectieID)
        {
            ServiciuD = new ServiciuData();

            ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Spital)
            //.Include(b => b.Author)
            .Include(b => b.ServiciuSectii)
            .ThenInclude(b => b.Sectie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire_Serviciu)
            .ToListAsync();
            if (id != null)
            {
                ServiciuID = id.Value;
                Serviciu Serviciu = ServiciuD.Servicii
                .Where(i => i.ID == id.Value).Single();
                ServiciuD.Sectii = Serviciu.ServiciuSectii.Select(s => s.Sectie);
            }
        }
    }
}
