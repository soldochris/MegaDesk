using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MegaDesk_Razor_Web_Application.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quote",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeskWidth = table.Column<int>(type: "int", nullable: false),
                    DeskHeight = table.Column<int>(type: "int", nullable: false),
                    MaterialOptions = table.Column<int>(type: "int", nullable: false),
                    NumberDrawers = table.Column<int>(type: "int", nullable: false),
                    ProductionTime = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quote", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quote");
        }
    }
}
