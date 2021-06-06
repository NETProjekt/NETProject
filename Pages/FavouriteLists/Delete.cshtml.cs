using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.FavouriteLists
{
    public class DeleteModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public DeleteModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FavouriteList FavouriteList { get; set; }

        public async Task<IActionResult> OnGetAsync(string applicationUserId, int? recipeId)
        {
            if (recipeId == null)
            {
                return NotFound();
            }
            if (applicationUserId == null)
            {
                return NotFound();
            }

            FavouriteList = await _context.FavouriteLists
                .Include(f => f.ApplicationUser).Where(a => a.ApplicationUserID == applicationUserId)
                .Include(f => f.Recipe).FirstOrDefaultAsync(m => m.RecipeID == recipeId);

            if (FavouriteList == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string applicationUserId, int? recipeId)
        {
            if (recipeId == null)
            {
                return NotFound();
            }
            if (applicationUserId == null)
            {
                return NotFound();
            }

            FavouriteList = await _context.FavouriteLists.FindAsync(applicationUserId, recipeId);

            if (FavouriteList != null)
            {
                _context.FavouriteLists.Remove(FavouriteList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
