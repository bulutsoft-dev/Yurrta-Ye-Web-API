// src/YurttaYe.Infrastructure/Persistence/Migrations/InitialCreate.cs
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YurttaYe.Infrastructure.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    DayOfWeek = table.Column<string>(maxLength: 20, nullable: false),
                    MinCalorie = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxCalorie = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Category = table.Column<string>(maxLength: 50, nullable: false),
                    GramajValue = table.Column<decimal>(nullable: false),
                    GramajUnit = table.Column<string>(maxLength: 10, nullable: false),
                    PriceValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PriceCurrency = table.Column<string>(maxLength: 3, nullable: true),
                    CalorieValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MenuId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItems_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItems_MenuId",
                table: "MenuItems",
                column: "MenuId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "MenuItems");
            migrationBuilder.DropTable(name: "Menus");
        }
    }
}