using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class RemovedUserName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_UserName_Email",
                schema: "usr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                schema: "usr",
                table: "User");

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
                name: "SupplayOrderPositionID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "SupplyOrderPositionID");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_Email",
                schema: "usr",
                table: "User",
                column: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_Email",
                schema: "usr",
                table: "User");

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
                name: "SupplyOrderPositionID",
                schema: "ord",
                table: "SupplyOrderPosition",
                newName: "SupplayOrderPositionID");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                schema: "usr",
                table: "User",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_UserName_Email",
                schema: "usr",
                table: "User",
                columns: new[] { "UserName", "Email" });
        }
    }
}
