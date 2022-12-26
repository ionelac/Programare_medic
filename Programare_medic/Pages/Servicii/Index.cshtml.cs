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
        public string DenumireServiciuSort { get; set; }
        public string MedicSort { get; set; }
        public decimal CostSort { get; set; }
        public string CurrentFilter { get; set; }

        //pentru a afisa doctorii de la fiecare sectie



        public async Task OnGetAsync(int? id, int? sectieID, string sortOrder, string
searchString)
        {
            ServiciuD = new ServiciuData();

            DenumireServiciuSort = String.IsNullOrEmpty(sortOrder) ? "denumire_serviciu_desc" : "";
            MedicSort = String.IsNullOrEmpty(sortOrder) ? "medic_desc" : "";

            CurrentFilter = searchString;

            ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Spital)
            .Include(b => b.Medic)
            .Include(b => b.ServiciuSectii)
            .ThenInclude(b => b.Sectie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire_Serviciu)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ServiciuD.Servicii = ServiciuD.Servicii.Where(s => s.Medic.Prenume.Contains(searchString)

               || s.Medic.Nume.Contains(searchString)
               || s.Denumire_Serviciu.Contains(searchString));
            }

            if (id != null)
            {
                ServiciuID = id.Value;
                Serviciu Serviciu = ServiciuD.Servicii
                .Where(i => i.ID == id.Value).Single();
                ServiciuD.Sectii = Serviciu.ServiciuSectii.Select(s => s.Sectie);
            }

            switch (sortOrder)
            {
                case "denumire_serviciu_desc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                   s.Denumire_Serviciu);
                    break;
                case "medic_desc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                   s.Medic.NumeComplet);
                    break;
            }

            }
        }
}
