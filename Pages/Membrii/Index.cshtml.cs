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
    public class IndexModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public IndexModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

        public IList<Membru> Membru { get;set; }

        public async Task OnGetAsync()
        {
            Membru = await _context.Membrii.ToListAsync();
        }
    }
}
