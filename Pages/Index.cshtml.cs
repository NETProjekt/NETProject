using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NET_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, NET_Projekt.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty(SupportsGet =true)]
        public int? CategoryRecipe { get; set; }
        public IList<CategoryRecipe> CategoryRecipes { get; set; }

        public void OnGet()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");
            if(CategoryRecipe!=null)
            {
                CategoryRecipes = _context.CategoryRecipes
                .Where(m => m.CategoryID == CategoryRecipe)
                .Include(c => c.Recipe)
                .Include(u => u.Recipe.ApplicationUser).ToList();
            }
            
        }
    }
}
