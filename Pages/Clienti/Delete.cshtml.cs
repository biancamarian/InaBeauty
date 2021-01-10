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
    public class DeleteModel : PageModel
    {
        private readonly InaBeauty.Models.SalonContext _context;

        public DeleteModel(InaBeauty.Models.SalonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Client Client { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Client = await _context.Clienti
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = "Deleted failed";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clienti
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (client == null)
            {
                return NotFound();
            }
            try
            {
                _context.Clienti.Remove(client);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch(DbUpdateConcurrencyException /* ex */)
            {
                return RedirectToAction("./Delete", new { id, saveChangesError = true });
            }
              
            
        }
    }
}
