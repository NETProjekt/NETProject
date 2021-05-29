using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Raitings
{
    public class IndexModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public IndexModel(NET_Projekt.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Raiting> Raiting { get;set; }

        public async Task OnGetAsync()
        {
            Raiting = await _context.Raitings
                .Include(r => r.ApplicationUser)
                .Include(r => r.Recipe).ToListAsync();
        }
    }
}
