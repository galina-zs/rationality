using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rationality.Migrations
{
    public partial class AddSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_Snack_SnackId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSnacks_Snack_SnackId",
                table: "ProductSnacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Snack_SnackId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Snack",
                table: "Snack");

            migrationBuilder.RenameTable(
                name: "Snack",
                newName: "Snacks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Snacks",
                table: "Snacks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Snacks_SnackId",
                table: "Day",
                column: "SnackId",
                principalTable: "Snacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSnacks_Snacks_SnackId",
                table: "ProductSnacks",
                column: "SnackId",
                principalTable: "Snacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Day_Snacks_SnackId",
                table: "Day");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductSnacks_Snacks_SnackId",
                table: "ProductSnacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Snacks_SnackId",
                table: "Recipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Snacks",
                table: "Snacks");

            migrationBuilder.RenameTable(
                name: "Snacks",
                newName: "Snack");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Snack",
                table: "Snack",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_Snack_SnackId",
                table: "Day",
                column: "SnackId",
                principalTable: "Snack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductSnacks_Snack_SnackId",
                table: "ProductSnacks",
                column: "SnackId",
                principalTable: "Snack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Snack_SnackId",
                table: "Recipes",
                column: "SnackId",
                principalTable: "Snack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
