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
    public class DetailsModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public DetailsModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

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
    }
}
