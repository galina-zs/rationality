using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rationality.Migrations
{
    public partial class AddDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Days",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BreakfastId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DinnerId = table.Column<int>(nullable: false),
                    LunchId = table.Column<int>(nullable: false),
                    SnackId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Days", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Days_Recipes_BreakfastId",
                        column: x => x.BreakfastId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Days_Recipes_DinnerId",
                        column: x => x.DinnerId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Days_Recipes_LunchId",
                        column: x => x.LunchId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Days_Snacks_SnackId",
                        column: x => x.SnackId,
                        principalTable: "Snacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Days_BreakfastId",
                table: "Days",
                column: "BreakfastId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_DinnerId",
                table: "Days",
                column: "DinnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_LunchId",
                table: "Days",
                column: "LunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_SnackId",
                table: "Days",
                column: "SnackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Days");
        }
    }
}
