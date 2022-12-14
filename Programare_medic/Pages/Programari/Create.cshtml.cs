using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_medic.Data;
using Programare_medic.Models;
using Microsoft.EntityFrameworkCore;


namespace Programare_medic.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly Programare_medic.Data.Programare_medicContext _context;

        public CreateModel(Programare_medic.Data.Programare_medicContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var serviciuList = _context.Serviciu
            .Include(b => b.Medic)
            .Select(x => new
                            {
                                x.ID,
                                ServiciuDenumireCompleta = x.Denumire_Serviciu + " - " + x.Medic.Nume + " " +x.Medic.Prenume
                            });
            ViewData["ServiciuID"] = new SelectList(serviciuList, "ID", "ServiciuDenumireCompleta");
            ViewData["PacientID"] = new SelectList(_context.Pacient, "ID","NumeComplet");

            return Page();
        }


        [BindProperty]
        public Programare Programare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
