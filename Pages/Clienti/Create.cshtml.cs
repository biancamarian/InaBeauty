using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InaBeauty.Models;

namespace InaBeauty.Pages.Clienti
{
    public class CreateModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public CreateModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyClient = new Client();

            if (await TryUpdateModelAsync<Client>(
                emptyClient,
                "client",   // Prefix for form value.
                s => s.Nume, s => s.Prenume, s => s.DataProgramare))
            {
                _context.Clienti.Add(emptyClient);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}
