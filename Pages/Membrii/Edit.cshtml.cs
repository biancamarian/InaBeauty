using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InaBeauty.Models;

namespace InaBeauty.Pages.Membrii
{
    public class EditModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public EditModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Membru Membru { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membru = await _context.Membrii.FirstOrDefaultAsync(m => m.Id == id);

            if (Membru == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Membru).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembruExists(Membru.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MembruExists(int id)
        {
            return _context.Membrii.Any(e => e.Id == id);
        }
    }
}
