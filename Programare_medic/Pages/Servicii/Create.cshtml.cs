using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_medic.Models;
using System.Security.Policy;

namespace Programare_medic.Pages.Servicii
{
    public class CreateModel : ServiciuSectiiPageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public CreateModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            /*
            var authorlist = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.LastName + " " + x.FirstName
            });
            
            ViewData["AuthorID"] = new SelectList(authorlist, "ID", "FullName");
            */
            ViewData["SpitalID"] = new SelectList(_context.Set<Spital>(), "ID","DenumireSpital");
            var serviciu = new Serviciu();
            serviciu.ServiciuSectii = new List<ServiciuSectie>();
            PopulareAtribuireSectieServiciu(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }

        //fhsjfhuieshfiuweh
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
