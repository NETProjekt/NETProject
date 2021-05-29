using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Raitings
{
    public class DeleteModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public DeleteModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Raiting Raiting { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Raiting = await _context.Raitings
                .Include(r => r.ApplicationUser)
                .Include(r => r.Recipe).FirstOrDefaultAsync(m => m.ApplicationUserID == id);

            if (Raiting == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Raiting = await _context.Raitings.FindAsync(id);

            if (Raiting != null)
            {
                _context.Raitings.Remove(Raiting);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
