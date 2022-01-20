using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class RemovedUsertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserType_UserTypeID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "usr");

            migrationBuilder.DropIndex(
                name: "IX_User_UserTypeID",
                schema: "usr",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserTypeID",
                schema: "usr",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypeID",
                schema: "usr",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "usr",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                schema: "usr",
                table: "User",
                column: "UserTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserType_UserTypeID",
                schema: "usr",
                table: "User",
                column: "UserTypeID",
                principalSchema: "usr",
                principalTable: "UserType",
                principalColumn: "UserTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
