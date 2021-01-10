using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using InaBeauty.Models;

namespace InaBeauty.Pages.Membrii
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
        public Membru Membru { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Membrii.Add(Membru);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
