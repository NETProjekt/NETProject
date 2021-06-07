using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NET_Projekt.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Nazwa Przepisu")]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "varchar(1000)")]
        [Display(Name = "Lista Składników")]
        public string IngredientsList { get; set; }
        [Required]
        [Column(TypeName = "varchar(3000)")]
        [Display(Name = "Opis Wykonania")]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Data Publikacji")]
        public DateTime PublicationDate { get; set; }
        public bool? Favourite { get; set; }
        public string ApplicationUserID { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<CategoryRecipe> CategoryRecipes { get; set; }
        public ICollection<Raiting> Raitings { get; set; }
    }
}
