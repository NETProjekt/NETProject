﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NET_Projekt.Data;

namespace NET_Projekt.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("NET_Projekt.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("NET_Projekt.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NET_Projekt.Models.CategoryRecipe", b =>
                {
                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("RecipeID")
                        .HasColumnType("int");

                    b.HasKey("CategoryID", "RecipeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("CategoryRecipes");
                });

            modelBuilder.Entity("NET_Projekt.Models.FavouriteList", b =>
                {
                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RecipeID")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserID", "RecipeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("FavouriteLists");
                });

            modelBuilder.Entity("NET_Projekt.Models.Raiting", b =>
                {
                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RecipeID")
                        .HasColumnType("int");

                    b.Property<bool?>("IsPositive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.HasKey("ApplicationUserID", "RecipeID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Raitings");
                });

            modelBuilder.Entity("NET_Projekt.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("varchar(3000)");

                    b.Property<bool?>("Favourite")
                        .HasColumnType("bit");

                    b.Property<string>("IngredientsList")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserID");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("NET_Projekt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("NET_Projekt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NET_Projekt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("NET_Projekt.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NET_Projekt.Models.Category", b =>
                {
                    b.HasOne("NET_Projekt.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Categories")
                        .HasForeignKey("ApplicationUserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NET_Projekt.Models.CategoryRecipe", b =>
                {
                    b.HasOne("NET_Projekt.Models.Category", "Category")
                        .WithMany("CategoryRecipes")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NET_Projekt.Models.Recipe", "Recipe")
                        .WithMany("CategoryRecipes")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NET_Projekt.Models.FavouriteList", b =>
                {
                    b.HasOne("NET_Projekt.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("FavouriteLists")
                        .HasForeignKey("ApplicationUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NET_Projekt.Models.Recipe", "Recipe")
                        .WithMany("FavouriteLists")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NET_Projekt.Models.Raiting", b =>
                {
                    b.HasOne("NET_Projekt.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Raitings")
                        .HasForeignKey("ApplicationUserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NET_Projekt.Models.Recipe", "Recipe")
                        .WithMany("Raitings")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NET_Projekt.Models.Recipe", b =>
                {
                    b.HasOne("NET_Projekt.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Recipes")
                        .HasForeignKey("ApplicationUserID")
                        .OnDelete(DeleteBehavior.SetNull);
                });
#pragma warning restore 612, 618
        }
    }
}
