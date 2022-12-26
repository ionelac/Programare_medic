using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programare_medic.Models;
using System.Data;
using System.Security.Policy;

namespace Programare_medic.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ServiciuSectiiPageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public EditModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            Serviciu = await _context.Serviciu
              .Include(b => b.Spital)
              .Include(b => b.Medic)
              .Include(b => b.ServiciuSectii).ThenInclude(b => b.Sectie)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

            PopulareAtribuireSectieServiciu(_context, Serviciu);
            if (Serviciu == null)
            {
                return NotFound();
            }

            var medicList = _context.Medic.Select(x => new
            {
                x.ID,
                NumeComplet = x.Nume + " " + x.Prenume
            });

            //Serviciu = serviciu;
            ViewData["SpitalID"] = new SelectList(_context.Set<Spital>(), "ID","DenumireSpital");
            ViewData["MedicID"] = new SelectList(medicList, "ID", "NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedSectii)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciuToUpdate = await _context.Serviciu
                .Include(i => i.Spital)
                .Include(i => i.Medic)
                .Include(i => i.ServiciuSectii)
                .ThenInclude(i => i.Sectie)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (serviciuToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Denumire_Serviciu, i => i.MedicID,
            i => i.Cost_consultatie, i => i.Data_Programare, i => i.SpitalID))
            {
                UpdateServiciuSectii(_context, selectedSectii, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            
            UpdateServiciuSectii(_context, selectedSectii, serviciuToUpdate);
            PopulareAtribuireSectieServiciu(_context, serviciuToUpdate);
            return Page();
        }


    }

}
