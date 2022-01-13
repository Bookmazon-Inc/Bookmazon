using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class Smallcorrectionsinmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplyOrderPosition_Book_BooksISBN",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyOrderPosition_SupplyOrder_SuppllyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.DropIndex(
                name: "IX_SupplyOrderPosition_BooksISBN",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.DropColumn(
                name: "BooksISBN",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.RenameColumn(
                name: "SupplayOrderStateID",
                schema: "ord",
                table: "SupplyOrderState",
                newName: "SupplyOrderStateID");

            migrationBuilder.RenameColumn(
                name: "SupplayOrderPositionStateID",
                schema: "ord",
                table: "SupplyOrderPositionState",
                newName: "SupplyOrderPositionStateID");

            migrationBuilder.RenameColumn(
                name: "SuppllyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "SupplyOrderID");

            migrationBuilder.RenameColumn(
                name: "SupplayOrderPositionID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "SupplyOrderPositionID");

            migrationBuilder.RenameIndex(
                name: "IX_SupplyOrderPosition_SuppllyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "IX_SupplyOrderPosition_SupplyOrderID");

            migrationBuilder.AddColumn<string>(
                name: "BookISBN",
                schema: "ord",
                table: "SupplyOrderPosition",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrderPosition_BookISBN",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "BookISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyOrderPosition_Book_BookISBN",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "BookISBN",
                principalSchema: "bok",
                principalTable: "Book",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyOrderPosition_SupplyOrder_SupplyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "SupplyOrderID",
                principalSchema: "ord",
                principalTable: "SupplyOrder",
                principalColumn: "SupplyOrderID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupplyOrderPosition_Book_BookISBN",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplyOrderPosition_SupplyOrder_SupplyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.DropIndex(
                name: "IX_SupplyOrderPosition_BookISBN",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.DropColumn(
                name: "BookISBN",
                schema: "ord",
                table: "SupplyOrderPosition");

            migrationBuilder.RenameColumn(
                name: "SupplyOrderStateID",
                schema: "ord",
                table: "SupplyOrderState",
                newName: "SupplayOrderStateID");

            migrationBuilder.RenameColumn(
                name: "SupplyOrderPositionStateID",
                schema: "ord",
                table: "SupplyOrderPositionState",
                newName: "SupplayOrderPositionStateID");

            migrationBuilder.RenameColumn(
                name: "SupplyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "SuppllyOrderID");

            migrationBuilder.RenameColumn(
                name: "SupplyOrderPositionID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "SupplayOrderPositionID");

            migrationBuilder.RenameIndex(
                name: "IX_SupplyOrderPosition_SupplyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "IX_SupplyOrderPosition_SuppllyOrderID");

            migrationBuilder.AddColumn<string>(
                name: "BooksISBN",
                schema: "ord",
                table: "SupplyOrderPosition",
                type: "nvarchar(13)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrderPosition_BooksISBN",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "BooksISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyOrderPosition_Book_BooksISBN",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "BooksISBN",
                principalSchema: "bok",
                principalTable: "Book",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplyOrderPosition_SupplyOrder_SuppllyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "SuppllyOrderID",
                principalSchema: "ord",
                principalTable: "SupplyOrder",
                principalColumn: "SupplyOrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
