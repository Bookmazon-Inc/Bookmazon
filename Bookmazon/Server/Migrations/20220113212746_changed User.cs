using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class changedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                schema: "usr",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "usr",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

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

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_UserName_Email",
                schema: "usr",
                table: "User",
                columns: new[] { "UserName", "Email" });

            migrationBuilder.AddForeignKey(
                name: "FK_Storage_Book_ISBN",
                schema: "str",
                table: "Storage",
                column: "ISBN",
                principalSchema: "bok",
                principalTable: "Book",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Storage_Book_ISBN",
                schema: "str",
                table: "Storage");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_UserName_Email",
                schema: "usr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NetPriceSell",
                schema: "bok",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PricePurchase",
                schema: "bok",
                table: "Book");

            migrationBuilder.AlterColumn<string>(
                name: "Salt",
                schema: "usr",
                table: "User",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                schema: "usr",
                table: "User",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
