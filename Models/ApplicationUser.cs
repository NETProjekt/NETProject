using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Recipe> Recipes { get; set; }
        public List<Category> Categories { get; set; }
    }
}
