using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InaBeauty.Models;
using InaBeauty.Models.SalonViewModels;

namespace InaBeauty.Pages.Membrii
{
    public class IndexModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public IndexModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

        public MembruIndexData Membru{ get; set; }
        public int MembruID { get; set; }
        public int ServiciuID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Membru = new MembruIndexData();

            Membru.Membrii = await _context.Membrii
                .Include(i=>i.AlocariServicii)
                 .ThenInclude(i=>i.Serviciu)
                 .AsNoTracking()
                 .OrderBy(i=> i.Nume)
                .ToListAsync();
            if (id != null)
            {
                MembruID = id.Value;
                Membru membru = Membru.Membrii.Where(i => i.Id == id.Value).Single();
                Membru.Servicii = membru.AlocariServicii.Select(s => s.Serviciu);

            }
        }
    }
}
