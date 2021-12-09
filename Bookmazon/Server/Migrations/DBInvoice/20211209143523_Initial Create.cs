using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations.DBInvoice
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inv");

            migrationBuilder.CreateTable(
                name: "InvoiceState",
                schema: "inv",
                columns: table => new
                {
                    InvoiceStateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceState", x => x.InvoiceStateID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                schema: "inv",
                columns: table => new
                {
                    InvoiceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ZIP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InvoiceStateID = table.Column<int>(type: "int", nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    VATPercentage = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoice_InvoiceState_InvoiceStateID",
                        column: x => x.InvoiceStateID,
                        principalSchema: "inv",
                        principalTable: "InvoiceState",
                        principalColumn: "InvoiceStateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePosition",
                schema: "inv",
                columns: table => new
                {
                    InvoicePositionID = table.Column<int>(type: "int", nullable: false),
                    InvoiceID = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    ProductTitle = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    NetPrice = table.Column<decimal>(type: "decimal (18,4)", nullable: false),
                    GrossPrice = table.Column<decimal>(type: "decimal (18,4)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePosition", x => new { x.InvoicePositionID, x.InvoiceID });
                    table.ForeignKey(
                        name: "FK_InvoicePosition_Invoice_InvoiceID",
                        column: x => x.InvoiceID,
                        principalSchema: "inv",
                        principalTable: "Invoice",
                        principalColumn: "InvoiceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceStateID",
                schema: "inv",
                table: "Invoice",
                column: "InvoiceStateID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePosition_InvoiceID",
                schema: "inv",
                table: "InvoicePosition",
                column: "InvoiceID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoicePosition",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "Invoice",
                schema: "inv");

            migrationBuilder.DropTable(
                name: "InvoiceState",
                schema: "inv");
        }
    }
}
