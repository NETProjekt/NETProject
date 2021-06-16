using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Recipes
{
   
    public class ProfileModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileModel(NET_Projekt.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Recipe> Recipe { get; set; }

        public async Task OnGetAsync(string id)
        {
            Recipe = await _context.Recipes
                .Include(r => r.ApplicationUser).Where(r => r.ApplicationUserID==id).OrderByDescending(r => r.PublicationDate).ToListAsync();
        }
    }
}
