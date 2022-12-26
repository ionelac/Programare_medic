using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_medic.Models;
using System.Data;
using System.Security.Policy;

namespace Programare_medic.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ServiciuSectiiPageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public CreateModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            var mediclist = _context.Medic.Select(x => new
            {
                x.ID,
                NumeComplet = x.Nume + " " + x.Prenume
            });
            
            ViewData["MedicID"] = new SelectList(mediclist, "ID", "NumeComplet");
            

            ViewData["SpitalID"] = new SelectList(_context.Set<Spital>(), "ID","DenumireSpital");
            var serviciu = new Serviciu();
            serviciu.ServiciuSectii = new List<ServiciuSectie>();
            PopulareAtribuireSectieServiciu(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedSectii)
        {
            var newServiciu = Serviciu;
            if (selectedSectii != null)
            {
                newServiciu.ServiciuSectii = new List<ServiciuSectie>();
                foreach (var cat in selectedSectii)
                {
                    var catToAdd = new ServiciuSectie
                    {
                        SectieID = int.Parse(cat)
                    };
                    newServiciu.ServiciuSectii.Add(catToAdd);
                }
            }

            _context.Serviciu.Add(newServiciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulareAtribuireSectieServiciu(_context, newServiciu);
            return Page();
        }

    }
}
