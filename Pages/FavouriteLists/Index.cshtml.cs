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

namespace NET_Projekt.Pages.FavouriteLists
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

        public IList<FavouriteList> FavouriteList { get;set; }

        public async Task OnGetAsync()
        {
            FavouriteList = await _context.FavouriteLists
                .Include(f => f.ApplicationUser).Where(m => m.ApplicationUserID == _userManager.GetUserId(User))
                .Include(f => f.Recipe)
                .ToListAsync();
        }
    }
}
