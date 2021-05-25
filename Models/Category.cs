using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(30)")]
        [Display(Name="Nazwa")]
        [Required]
        public string Name { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
    }
}
