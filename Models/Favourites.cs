using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Models
{
    public class Favourite
    {
        [Required]
        public bool? Fav { get; set; }
        public Recipe Recipe { get; set; }
        public int RecipeID { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
