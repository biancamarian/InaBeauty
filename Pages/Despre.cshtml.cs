using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InaBeauty.Models;
using InaBeauty.Models.SalonViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace InaBeauty.Pages
{
    public class DespreModel : PageModel
    {
       private readonly SalonContext _context;
       public DespreModel(SalonContext context)
        {
            _context = context;
        }
        public IList<ProgramareDateGroup> Client { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<ProgramareDateGroup> data =
                 from client in _context.Clienti
                 group client by client.DataProgramare into dateGroup
                 select new ProgramareDateGroup()
                 {
                     DataProgramare = dateGroup.Key,
                     ClientiNr = dateGroup.Count()
                 };
            Client = await data.AsNoTracking().ToListAsync();
        }
    }
}
