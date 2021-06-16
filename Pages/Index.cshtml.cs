using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NET_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly NET_Projekt.Data.ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, NET_Projekt.Data.ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [BindProperty(SupportsGet = true)]
        public int? CategoryRecipe { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Recipe { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Username { get; set; }
        public new ApplicationUser User { get; set; }
        public Dictionary<Recipe, int> Sort { get; set; }
        public IList<CategoryRecipe> CategoryRecipes { get; set; }
        public IList<Recipe> Recipes { get; set; }
        public IList<Raiting> Raitings { get; set; }
        public IList<Recipe> AllRecipes { get; set; }
        public IList<Recipe> Top10Re { get; set; }


        public void OnGet()
        {
            Raitings = _context.Raitings.ToList();
            AllRecipes = _context.Recipes
                        .Include(r => r.ApplicationUser).ToList();
            Sort = new Dictionary<Recipe, int>();
            int sum = 0;
            foreach (var item in AllRecipes)
            {
                foreach (var rat in Raitings)
                {
                    if (item.Id == rat.RecipeID && rat.IsPositive == true)
                        sum += Convert.ToInt32(rat.IsPositive);
                }
                Sort.Add(item, sum);
            }
            var sortedDict = from entry in Sort orderby entry.Value descending select entry;

            Top10Re = new List<Recipe>();
            int counter = 0;
            foreach (KeyValuePair<Recipe, int> entry in sortedDict)
            {
                if (counter >= 10)
                    break;
                Top10Re.Add(entry.Key);
                counter++;
            }

            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");
            if (CategoryRecipe != null)
            {
                CategoryRecipes = _context.CategoryRecipes
                .Where(m => m.CategoryID == CategoryRecipe)
                .Include(c => c.Recipe)
                .Include(u => u.Recipe.ApplicationUser).ToList();
            }
        }
        public void OnGetUsername()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");
            if (Username != null)
            {
                Recipes = _context.Recipes
                    .Where(r => r.ApplicationUser.UserName.Contains(Username))
                    .Include(u => u.ApplicationUser)
                    .OrderByDescending(r => r.PublicationDate)
                    .ToList();
            }
        }
        public void OnGetName()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");
            if (Recipe != null)
            {
                Recipes = _context.Recipes
                    .Where(r => r.Name.Contains(Recipe))
                    .Include(u => u.ApplicationUser)
                    .OrderByDescending(r => r.PublicationDate)
                    .ToList();
            }
        }

    }
}
