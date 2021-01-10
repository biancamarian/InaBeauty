using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using InaBeauty.Models;

namespace InaBeauty.Pages.Clienti
{
    public class IndexModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public IndexModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }
        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
         public PaginatedList<Client> Client { get; set; }
        
        public async Task OnGetAsync(string sortOrder, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            // using System;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = CurrentFilter;
            }
            CurrentFilter = searchString;
            IQueryable<Client> clientiIQ = from s in _context.Clienti
                                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                clientiIQ = clientiIQ.Where(s => s.Nume.Contains(searchString) || s.Prenume.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    clientiIQ = clientiIQ.OrderByDescending(s => s.Nume);
                    break;
                case "Date":
                    clientiIQ = clientiIQ.OrderBy(s => s.DataProgramare);
                    break;
                case "date_desc":
                    clientiIQ = clientiIQ.OrderByDescending(s => s.DataProgramare);
                    break;
                default:
                    clientiIQ = clientiIQ.OrderBy(s => s.Nume);
                    break;
            }
            int pageSize = 4;
            Client = await PaginatedList<Client>.CreateAsync(
                clientiIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
