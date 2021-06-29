using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Rationality.Data;
using Rationality.Models;
using System;

namespace Rationality.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210629055442_AddProductSnacks")]
    partial class AddProductSnacks
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
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
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Rationality.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("Activity");

                    b.Property<int>("Age");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("Gender");

                    b.Property<int>("Goal");

                    b.Property<int>("Height");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<int>("MoneyPerMonth");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<int>("Weight");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Rationality.Models.Day", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ApplicationUserId");

                    b.Property<string>("ApplicationUserId1");

                    b.Property<int>("BreakfastId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("DinnerId");

                    b.Property<int>("LunchId");

                    b.Property<int>("SnackId");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId1");

                    b.HasIndex("BreakfastId");

                    b.HasIndex("DinnerId");

                    b.HasIndex("LunchId");

                    b.HasIndex("SnackId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("Rationality.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Carbohydrates");

                    b.Property<int>("Fats");

                    b.Property<bool>("IsSnack");

                    b.Property<int>("Kcal");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.Property<int>("Proteins");

                    b.Property<int>("Unit");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Rationality.Models.ProductSnack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("Picture");

                    b.Property<int>("ProductId");

                    b.Property<int?>("SnackId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SnackId");

                    b.ToTable("ProductSnacks");
                });

            modelBuilder.Entity("Rationality.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Carbohydrates");

                    b.Property<string>("CookingMethod");

                    b.Property<int>("Fats");

                    b.Property<int>("Kcal");

                    b.Property<int>("Meal");

                    b.Property<string>("Name");

                    b.Property<string>("Picture");

                    b.Property<double>("Price");

                    b.Property<int>("Proteins");

                    b.Property<int?>("SnackId");

                    b.HasKey("Id");

                    b.HasIndex("SnackId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Rationality.Models.RecipeProduct", b =>
                {
                    b.Property<int>("RecipeId");

                    b.Property<int>("ProductId");

                    b.Property<double>("Amount");

                    b.Property<int>("Unit");

                    b.HasKey("RecipeId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("RecipeProducts");
                });

            modelBuilder.Entity("Rationality.Models.Snack", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Picture");

                    b.HasKey("Id");

                    b.ToTable("Snacks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Rationality.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Rationality.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rationality.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Rationality.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Rationality.Models.Day", b =>
                {
                    b.HasOne("Rationality.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId1");

                    b.HasOne("Rationality.Models.Recipe", "Breakfast")
                        .WithMany()
                        .HasForeignKey("BreakfastId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Rationality.Models.Recipe", "Dinner")
                        .WithMany()
                        .HasForeignKey("DinnerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Rationality.Models.Recipe", "Lunch")
                        .WithMany()
                        .HasForeignKey("LunchId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Rationality.Models.Snack", "Snack")
                        .WithMany()
                        .HasForeignKey("SnackId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Rationality.Models.ProductSnack", b =>
                {
                    b.HasOne("Rationality.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rationality.Models.Snack")
                        .WithMany("ProductSnacks")
                        .HasForeignKey("SnackId");
                });

            modelBuilder.Entity("Rationality.Models.Recipe", b =>
                {
                    b.HasOne("Rationality.Models.Snack")
                        .WithMany("Recipes")
                        .HasForeignKey("SnackId");
                });

            modelBuilder.Entity("Rationality.Models.RecipeProduct", b =>
                {
                    b.HasOne("Rationality.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Rationality.Models.Recipe", "Recipe")
                        .WithMany("RecipeProducts")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
