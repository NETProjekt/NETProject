using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Models
{
    public class CategoryRecipe
    {
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
