using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rationality.Migrations
{
    public partial class AddRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipe_BreakfastId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipe_DinnerId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipe_LunchId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipe_Snack_SnackId",
                table: "Recipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe");

            migrationBuilder.RenameTable(
                name: "Recipe",
                newName: "Recipes");

            migrationBuilder.RenameIndex(
                name: "IX_Recipe_SnackId",
                table: "Recipes",
                newName: "IX_Recipes_SnackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipes_BreakfastId",
                table: "Day",
                column: "BreakfastId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipes_DinnerId",
                table: "Day",
                column: "DinnerId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipes_LunchId",
                table: "Day",
                column: "LunchId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Snack_SnackId",
                table: "Recipes",
                column: "SnackId",
                principalTable: "Snack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipes_BreakfastId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipes_DinnerId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Day_Recipes_LunchId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Snack_SnackId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Recipe");

            migrationBuilder.RenameIndex(
                name: "IX_Recipes_SnackId",
                table: "Recipe",
                newName: "IX_Recipe_SnackId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipe",
                table: "Recipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipe_BreakfastId",
                table: "Day",
                column: "BreakfastId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipe_DinnerId",
                table: "Day",
                column: "DinnerId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Recipe_LunchId",
                table: "Day",
                column: "LunchId",
                principalTable: "Recipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipe_Snack_SnackId",
                table: "Recipe",
                column: "SnackId",
                principalTable: "Snack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
