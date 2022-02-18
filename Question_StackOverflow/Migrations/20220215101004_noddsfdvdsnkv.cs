using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Question_StackOverflow.Migrations
{
    public partial class noddsfdvdsnkv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Bars_ParentBarId",
                table: "Bars");

            migrationBuilder.DropIndex(
                name: "IX_Bars_ParentBarId",
                table: "Bars");

            migrationBuilder.AddColumn<Guid>(
                name: "BarId",
                table: "Bars",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bars_BarId",
                table: "Bars",
                column: "BarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Bars_BarId",
                table: "Bars",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bars_Bars_BarId",
                table: "Bars");

            migrationBuilder.DropIndex(
                name: "IX_Bars_BarId",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "BarId",
                table: "Bars");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_ParentBarId",
                table: "Bars",
                column: "ParentBarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bars_Bars_ParentBarId",
                table: "Bars",
                column: "ParentBarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
