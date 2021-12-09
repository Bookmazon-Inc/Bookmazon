using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class changedStorageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
