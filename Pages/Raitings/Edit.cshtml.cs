using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Raitings
{
    public class EditModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public EditModel(NET_Projekt.Data.ApplicationDbContext context)
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
           ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id");
           ViewData["RecipeID"] = new SelectList(_context.Recipes, "Id", "Content");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Raiting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaitingExists(Raiting.ApplicationUserID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool RaitingExists(string id)
        {
            return _context.Raitings.Any(e => e.ApplicationUserID == id);
        }
    }
}
