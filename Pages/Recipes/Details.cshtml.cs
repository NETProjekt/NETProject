using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public DetailsModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes
                .Include(r => r.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
