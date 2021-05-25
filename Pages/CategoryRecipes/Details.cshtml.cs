﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public DetailsModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
