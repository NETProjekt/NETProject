using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NET_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NET_Projekt.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryRecipe> CategoryRecipes { get; set; }
        public DbSet<FavouriteList> FavouriteLists { get; set; }
        public DbSet<Raiting> Raitings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Recipe>()
                .HasOne(us => us.ApplicationUser)
                .WithMany(rc => rc.Recipes)
                .HasForeignKey(us => us.ApplicationUserID)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Category>()
                .HasOne(us => us.ApplicationUser)
                .WithMany(ct => ct.Categories)
                .HasForeignKey(us => us.ApplicationUserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CategoryRecipe>()
                .HasKey(bc => new { bc.CategoryID, bc.RecipeID });
            modelBuilder.Entity<CategoryRecipe>()
                .HasOne(bc => bc.Category)
                .WithMany(b => b.CategoryRecipes)
                .HasForeignKey(bc => bc.CategoryID);
            modelBuilder.Entity<CategoryRecipe>()
                .HasOne(bc => bc.Recipe)
                .WithMany(c => c.CategoryRecipes)
                .HasForeignKey(bc => bc.RecipeID);

            modelBuilder.Entity<Raiting>()
                .HasKey(bc => new { bc.ApplicationUserID, bc.RecipeID });
            modelBuilder.Entity<Raiting>()
                .HasOne(bc => bc.ApplicationUser)
                .WithMany(b => b.Raitings)
                .HasForeignKey(bc => bc.ApplicationUserID);
            modelBuilder.Entity<Raiting>()
                .HasOne(bc => bc.Recipe)
                .WithMany(c => c.Raitings)
                .HasForeignKey(bc => bc.RecipeID);

            modelBuilder.Entity<FavouriteList>()
                .HasKey(bc => new { bc.ApplicationUserID, bc.RecipeID });
            modelBuilder.Entity<FavouriteList>()
                .HasOne(bc => bc.ApplicationUser)
                .WithMany(b => b.FavouriteLists)
                .HasForeignKey(bc => bc.ApplicationUserID);
            modelBuilder.Entity<FavouriteList>()
                .HasOne(bc => bc.Recipe)
                .WithMany(c => c.FavouriteLists)
                .HasForeignKey(bc => bc.RecipeID);
        }
    }
}
