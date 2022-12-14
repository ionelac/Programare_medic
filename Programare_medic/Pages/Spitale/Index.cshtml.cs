using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Data;
using Programare_medic.Models;
using Programare_medic.Models.ViewModels;


namespace Programare_medic.Pages.Spitale
{
    public class IndexModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public IndexModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public IList<Spital> Spital { get;set; } = default!;

        public SpitalIndexData SpitalData { get; set; }
        public int SpitalID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            SpitalData = new SpitalIndexData();
            SpitalData.Spitale = await _context.Spital
            .Include(i => i.Servicii)
            .ThenInclude(c => c.Medic)
            .OrderBy(i => i.DenumireSpital)
            .ToListAsync();
            if (id != null)
            {
                SpitalID = id.Value;
                Spital publisher = SpitalData.Spitale
                .Where(i => i.ID == id.Value).Single();
                SpitalData.Servicii = publisher.Servicii;
            }
        }
    }
}
