using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class addpricefieldstobook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NetPriceSell",
                schema: "bok",
                table: "Book",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PricePurchase",
                schema: "bok",
                table: "Book",
                type: "decimal(18,4)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetPriceSell",
                schema: "bok",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PricePurchase",
                schema: "bok",
                table: "Book");
        }
    }
}
