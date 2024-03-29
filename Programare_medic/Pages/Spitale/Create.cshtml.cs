﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_medic.Data;
using Programare_medic.Models;

namespace Programare_medic.Pages.Spitale
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
            return Page();
        }

        [BindProperty]
        public Spital Spital { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Spital.Add(Spital);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
