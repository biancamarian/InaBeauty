using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InaBeauty.Models;

namespace InaBeauty.Pages.Membrii
{
    public class DeleteModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public DeleteModel(InaBeauty.Models.SalonContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Membru = await _context.Membrii.FindAsync(id);

            if (Membru != null)
            {
                _context.Membrii.Remove(Membru);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
