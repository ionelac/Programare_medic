using Microsoft.AspNetCore.Mvc.RazorPages;
using Programare_medic.Data;

namespace Programare_medic.Models

{
    public class ServiciuSectiiPageModel : PageModel
    {
        public List<SectieAtribuitaServiciu> SectieAtribuitaServiciuList;
        public void PopulareAtribuireSectieServiciu(Programare_medicContext context, Serviciu serviciu)
        {
            var allSectii = context.Sectie;
            var serviciuSectii = new HashSet<int>(
            serviciu.ServiciuSectii.Select(c => c.SectieID)); //
            SectieAtribuitaServiciuList = new List<SectieAtribuitaServiciu>();
            foreach (var cat in allSectii)
            {
                SectieAtribuitaServiciuList.Add(new SectieAtribuitaServiciu
                {
                    SectieID = cat.ID,
                    Denumire = cat.DenumireSectie,
                    Atribuire = serviciuSectii.Contains(cat.ID)
                });
            }
        }
        public void UpdateServiciuSectii(Programare_medicContext context,
        string[] selectedServicii, Serviciu serviciuToUpdate)
        {
            if (selectedServicii == null)
            {
                serviciuToUpdate.ServiciuSectii = new List<ServiciuSectie>();
                return;
            }
            var selectedSectiiHS = new HashSet<string>(selectedServicii);
            var serviciuSectii = new HashSet<int>
            (serviciuToUpdate.ServiciuSectii.Select(c => c.Sectie.ID));
            foreach (var cat in context.Sectie)
            {
                if (selectedSectiiHS.Contains(cat.ID.ToString()))
                {
                    if (!serviciuSectii.Contains(cat.ID))
                    {
                        serviciuToUpdate.ServiciuSectii.Add(
                        new ServiciuSectie
                        {
                            ServiciuID = serviciuToUpdate.ID,
                            SectieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (serviciuSectii.Contains(cat.ID))
                    {
                        ServiciuSectie courseToRemove
                        = serviciuToUpdate
                        .ServiciuSectii
                        .SingleOrDefault(i => i.SectieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
