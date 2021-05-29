using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Models
{
    public class Raiting
    {
        public bool? IsPositive { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
