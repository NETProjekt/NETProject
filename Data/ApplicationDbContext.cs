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
        }
    }
}
