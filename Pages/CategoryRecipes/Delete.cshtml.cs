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
    public class DeleteModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public DeleteModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryRecipe CategoryRecipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? recipeId, int? categoryId)
        {
            if (recipeId == null)
            {
                return NotFound();
            }
            if (categoryId == null)
            {
                return NotFound();
            }
            CategoryRecipe = await _context.CategoryRecipes
                .Include(c => c.Category).Where(m => m.CategoryID == categoryId)
                .Include(c => c.Recipe).FirstOrDefaultAsync(m => m.RecipeID == recipeId);

            if (CategoryRecipe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? recipeId, int? categoryId)
        {
            if (recipeId == null)
            {
                return NotFound();
            }
            if (categoryId == null)
            {
                return NotFound();
            }

            CategoryRecipe = await _context.CategoryRecipes.FindAsync(categoryId, recipeId);

            if (CategoryRecipe != null)
            {
                _context.CategoryRecipes.Remove(CategoryRecipe);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Categories/Index");
        }
    }
}
