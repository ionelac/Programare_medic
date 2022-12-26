using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Data;
using Programare_medic.Models;

namespace Programare_medic.Pages.Programari
{
    public class IndexModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public IndexModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }


        public IList<Programare> Programare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Programare != null)
            {
                Programare = await _context.Programare
                .Include(b => b.Serviciu)
                 .ThenInclude(b => b.Medic)
                .Include(b => b.Pacient).ToListAsync();
            }
        }
    }
}
