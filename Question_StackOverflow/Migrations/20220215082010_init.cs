using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Question_StackOverflow.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Foos_MainEntities_MainEntityId",
                        column: x => x.MainEntityId,
                        principalTable: "MainEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ParentBarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bars_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bars_Foos_FooId",
                        column: x => x.FooId,
                        principalTable: "Foos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bars_BarId",
                table: "Bars",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_FooId",
                table: "Bars",
                column: "FooId");

            migrationBuilder.CreateIndex(
                name: "IX_Foos_MainEntityId",
                table: "Foos",
                column: "MainEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Foos");

            migrationBuilder.DropTable(
                name: "MainEntities");
        }
    }
}
