using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InaBeauty.Models;

namespace InaBeauty.Pages.Servicii
{
    public class DetailsModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public DetailsModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

        public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Serviciu = await _context.Servicii.FirstOrDefaultAsync(m => m.ServiciuID == id);

            if (Serviciu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
