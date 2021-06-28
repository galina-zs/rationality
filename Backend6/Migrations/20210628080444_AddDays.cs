using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Rationality.Migrations
{
    public partial class AddDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_AspNetUsers_ApplicationUserId1",
                table: "Day");

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
                name: "FK_Day_Snacks_SnackId",
                table: "Day");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Day",
                table: "Day");

            migrationBuilder.RenameTable(
                name: "Day",
                newName: "Days");

            migrationBuilder.RenameIndex(
                name: "IX_Day_SnackId",
                table: "Days",
                newName: "IX_Days_SnackId");

            migrationBuilder.RenameIndex(
                name: "IX_Day_LunchId",
                table: "Days",
                newName: "IX_Days_LunchId");

            migrationBuilder.RenameIndex(
                name: "IX_Day_DinnerId",
                table: "Days",
                newName: "IX_Days_DinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Day_BreakfastId",
                table: "Days",
                newName: "IX_Days_BreakfastId");

            migrationBuilder.RenameIndex(
                name: "IX_Day_ApplicationUserId1",
                table: "Days",
                newName: "IX_Days_ApplicationUserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_AspNetUsers_ApplicationUserId1",
                table: "Days",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Recipes_BreakfastId",
                table: "Days",
                column: "BreakfastId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Recipes_DinnerId",
                table: "Days",
                column: "DinnerId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Recipes_LunchId",
                table: "Days",
                column: "LunchId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_Snacks_SnackId",
                table: "Days",
                column: "SnackId",
                principalTable: "Snacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_AspNetUsers_ApplicationUserId1",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Recipes_BreakfastId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Recipes_DinnerId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Recipes_LunchId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_Snacks_SnackId",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.RenameTable(
                name: "Days",
                newName: "Day");

            migrationBuilder.RenameIndex(
                name: "IX_Days_SnackId",
                table: "Day",
                newName: "IX_Day_SnackId");

            migrationBuilder.RenameIndex(
                name: "IX_Days_LunchId",
                table: "Day",
                newName: "IX_Day_LunchId");

            migrationBuilder.RenameIndex(
                name: "IX_Days_DinnerId",
                table: "Day",
                newName: "IX_Day_DinnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Days_BreakfastId",
                table: "Day",
                newName: "IX_Day_BreakfastId");

            migrationBuilder.RenameIndex(
                name: "IX_Days_ApplicationUserId1",
                table: "Day",
                newName: "IX_Day_ApplicationUserId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Day",
                table: "Day",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_AspNetUsers_ApplicationUserId1",
                table: "Day",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Day_Snacks_SnackId",
                table: "Day",
                column: "SnackId",
                principalTable: "Snacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
