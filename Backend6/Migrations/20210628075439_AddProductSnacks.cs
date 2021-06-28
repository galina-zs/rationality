using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rationality.Migrations
{
    public partial class AddProductSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Snack",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductSnacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<double>(nullable: false),
                    Picture = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    SnackId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSnacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSnacks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSnacks_Snack_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Carbohydrates = table.Column<int>(nullable: false),
                    CookingMethod = table.Column<string>(nullable: true),
                    Fats = table.Column<int>(nullable: false),
                    Kcal = table.Column<int>(nullable: false),
                    Meal = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Proteins = table.Column<int>(nullable: false),
                    SnackId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_Snack_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<int>(nullable: false),
                    ApplicationUserId1 = table.Column<string>(nullable: true),
                    BreakfastId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DinnerId = table.Column<int>(nullable: false),
                    LunchId = table.Column<int>(nullable: false),
                    SnackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Day_Recipe_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Day_Recipe_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Day_Recipe_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Day_Snack_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Day_ApplicationUserId1",
                table: "Day",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Day_BreakfastId",
                table: "Day",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_DinnerId",
                table: "Day",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_LunchId",
                table: "Day",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_SnackId",
                table: "Day",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSnacks_ProductId",
                table: "ProductSnacks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSnacks_SnackId",
                table: "ProductSnacks",
                column: "SnackId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_SnackId",
                table: "Recipe",
                column: "SnackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropTable(
                name: "ProductSnacks");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Snack");
        }
    }
}
