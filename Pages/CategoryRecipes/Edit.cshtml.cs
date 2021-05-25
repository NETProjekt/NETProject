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

namespace NET_Projekt.Pages.CategoryRecipes
{
    public class EditModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public EditModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CategoryRecipe CategoryRecipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CategoryRecipe = await _context.CategoryRecipes
                .Include(c => c.Category)
                .Include(c => c.Recipe).FirstOrDefaultAsync(m => m.CategoryID == id);

            if (CategoryRecipe == null)
            {
                return NotFound();
            }
           ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");
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

            _context.Attach(CategoryRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryRecipeExists(CategoryRecipe.CategoryID))
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

        private bool CategoryRecipeExists(int id)
        {
            return _context.CategoryRecipes.Any(e => e.CategoryID == id);
        }
    }
}
