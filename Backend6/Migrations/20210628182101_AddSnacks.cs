using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rationality.Migrations
{
    public partial class AddSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SnackId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Picture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_SnackId",
                table: "Recipes",
                column: "SnackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Snacks_SnackId",
                table: "Recipes",
                column: "SnackId",
                principalTable: "Snacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Snacks_SnackId",
                table: "Recipes");

            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_SnackId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "SnackId",
                table: "Recipes");
        }
    }
}
