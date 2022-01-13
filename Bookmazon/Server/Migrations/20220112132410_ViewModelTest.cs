using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class ViewModelTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_User_UserName_Email",
                schema: "usr",
                table: "User",
                columns: new[] { "UserName", "Email" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_User_UserName_Email",
                schema: "usr",
                table: "User");
        }
    }
}
