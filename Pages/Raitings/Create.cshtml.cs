using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Raitings
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
        ViewData["ApplicationUserID"] = new SelectList(_context.Users, "Id", "Id");
        ViewData["RecipeID"] = new SelectList(_context.Recipes, "Id", "Content");
            return Page();
        }

        [BindProperty]
        public Raiting Raiting { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Raitings.Add(Raiting);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
