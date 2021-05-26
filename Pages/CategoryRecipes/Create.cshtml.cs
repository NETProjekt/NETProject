using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.CategoryRecipes
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;
        public string name;

        public CreateModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet =true)]
        public CategoryRecipe CategoryRecipe { get; set; }

        public IActionResult OnGet(int? id, string name)
        {
            if(id == null)
            {
                NotFound();
            }
            CategoryRecipe.CategoryID = (int)id;
            this.name = name;
        //ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");
        ViewData["RecipeID"] = new SelectList(_context.Recipes, "Id", "Name");
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

            _context.CategoryRecipes.Add(CategoryRecipe);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Categories/Index");
        }
    }
}
