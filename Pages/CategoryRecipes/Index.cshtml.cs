using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.CategoryRecipes
{
    public class IndexModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public IndexModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CategoryRecipe> CategoryRecipe { get;set; }

        public async Task OnGetAsync(int? id)
        {
            if(id == null)
            {
                NotFound();
            }
            CategoryRecipe = await _context.CategoryRecipes
                .Include(c => c.Category)
                .Where(m => m.Category.Id == id)
                .Include(c => c.Recipe).ToListAsync();
        }
    }
}
