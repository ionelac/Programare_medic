using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Data;
using Programare_medic.Models;

namespace Programare_medic.Pages.Pacienti
{
    public class IndexModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public IndexModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public IList<Pacient> Pacient { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pacient != null)
            {
                Pacient = await _context.Pacient.ToListAsync();
            }
        }
    }
}
