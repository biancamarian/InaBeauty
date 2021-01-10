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
    public class IndexModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public IndexModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; }

        public async Task OnGetAsync()
        {
            Serviciu = await _context.Servicii.ToListAsync();
        }
    }
}
