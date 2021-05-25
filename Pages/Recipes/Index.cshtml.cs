using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Recipes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(NET_Projekt.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes
                .Where(r => r.ApplicationUserID == _userManager.GetUserId(User))
                .Include(r => r.ApplicationUser).ToListAsync();
        }
    }
}
