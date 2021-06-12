using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Data;
using NET_Projekt.Models;

namespace NET_Projekt.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly NET_Projekt.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public bool isInFavourite { get; set; }
        public bool isRated { get; set; }
        public int Raiting { get; set; }
        public int Ratio { get; set; }

        public DetailsModel(NET_Projekt.Data.ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public FavouriteList FavouriteList { get; set; }
        public Recipe Recipe { get; set; }
        public Raiting NewRaiting { get; set; }
        public IList<Raiting> Raitings { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await GetData(id);
            return Page();
        }
        [BindProperty]
        public bool? IsPositive { get; set; } 
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                await GetData(id);
                return Page();
            }
            NewRaiting = await _context.Raitings
                .Include(r => r.ApplicationUser)
                .Include(c => c.Recipe)
                .FirstOrDefaultAsync(m => m.ApplicationUserID == _userManager.GetUserId(User) && m.RecipeID == id);
            if (NewRaiting == null)
            {
                NewRaiting = new Raiting();
                NewRaiting.ApplicationUserID = _userManager.GetUserId(User);
                NewRaiting.RecipeID = (int)id;
                NewRaiting.IsPositive = IsPositive;
                _context.Raitings.Add(NewRaiting);
                await _context.SaveChangesAsync();
            }
            else
            {
                NewRaiting.ApplicationUserID = _userManager.GetUserId(User);
                NewRaiting.RecipeID = (int)id;
                NewRaiting.IsPositive = IsPositive;
                await _context.SaveChangesAsync();
            }
            await GetData(id);
            return Page();
        }
        public async Task<IActionResult> OnPostDelete(int? recipeId, string applicationUserId)
        {
            if (recipeId == null)
            {
                return NotFound();
            }
            if (applicationUserId == null)
            {
                return NotFound();
            }

            NewRaiting = await _context.Raitings.FindAsync(applicationUserId, recipeId);

            if (NewRaiting != null)
            {
                _context.Raitings.Remove(NewRaiting);
                await _context.SaveChangesAsync();
            }
            await GetData(recipeId);
            return Page(); 
        }
        public async Task<IActionResult> OnPostFavourite(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string applicationUser = _userManager.GetUserId(User);
            FavouriteList = new FavouriteList();
            FavouriteList.ApplicationUserID = _userManager.GetUserId(User);
            FavouriteList.RecipeID = (int)id;

            if (await _context.FavouriteLists.FindAsync(applicationUser, id) == null)
            {
                _context.FavouriteLists.Add(FavouriteList);
                await _context.SaveChangesAsync();
            }
            await GetData(id);
            return Page();
        }
        public async Task<IActionResult> GetData(int? id)
        {
            FavouriteList = await _context.FavouriteLists.FindAsync(_userManager.GetUserId(User), id);

            Recipe = await _context.Recipes
                .Include(r => r.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

            Raitings = await _context.Raitings
                .Include(rc => rc.Recipe).AsNoTracking().Where(rc => rc.RecipeID == id).ToListAsync();

            int sum = 0;
            isRated = false;
            isInFavourite = true;

            if (FavouriteList == null)
                isInFavourite = false;

            foreach (var item in Raitings)
            {
                if (_userManager.GetUserId(User) == item.ApplicationUserID)
                    isRated = true;
                sum += Convert.ToInt32(item.IsPositive);
            }

            Raiting = sum;
            decimal dRaiting = Raiting;
            decimal dRaitings = Raitings.Count;

            if (Raitings.Count != 0)
                Ratio = Convert.ToInt32(dRaiting / dRaitings * 100);
            else
                Ratio = 50;

            if (Recipe == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
