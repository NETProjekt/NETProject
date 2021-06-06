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
    public class IndexModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public IndexModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FavouriteList> FavouriteList { get;set; }

        public async Task OnGetAsync()
        {
            FavouriteList = await _context.FavouriteLists
                .Include(f => f.ApplicationUser)
                .Include(f => f.Recipe).ToListAsync();
        }
    }
}
