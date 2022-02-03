using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class AddedSupplierAdressandEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "bok",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "bok",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HouseNumber",
                schema: "bok",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Land",
                schema: "bok",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                schema: "bok",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                schema: "bok",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "bok",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "bok",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                schema: "bok",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Land",
                schema: "bok",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "bok",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Street",
                schema: "bok",
                table: "Supplier");
        }
    }
}
