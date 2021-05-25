﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.CategoryRecipes
{
    public class CreateModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public CreateModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");
        ViewData["RecipeID"] = new SelectList(_context.Recipes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public CategoryRecipe CategoryRecipe { get; set; }

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

            return RedirectToPage("./Index");
        }
    }
}
