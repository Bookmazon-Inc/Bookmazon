using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "bok");

            migrationBuilder.EnsureSchema(
                name: "ord");

            migrationBuilder.EnsureSchema(
                name: "usr");

            migrationBuilder.EnsureSchema(
                name: "str");

            migrationBuilder.CreateTable(
                name: "Author",
                schema: "bok",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Penname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderPositionState",
                schema: "ord",
                columns: table => new
                {
                    CustomerOrderPositionStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderPositionState", x => x.CustomerOrderPositionStateId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderState",
                schema: "ord",
                columns: table => new
                {
                    CustomerOrderStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderState", x => x.CustomerOrderStateId);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                schema: "bok",
                columns: table => new
                {
                    DiscountId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    DiscountPercentage = table.Column<int>(type: "int", nullable: true),
                    DiscountName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.DiscountId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                schema: "bok",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                schema: "bok",
                columns: table => new
                {
                    LanguageCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.LanguageCode);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                schema: "bok",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "usr",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "StorageLocation",
                schema: "str",
                columns: table => new
                {
                    StorageLocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocation", x => x.StorageLocationID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                schema: "bok",
                columns: table => new
                {
                    SupplierID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.SupplierID);
                });

            migrationBuilder.CreateTable(
                name: "SupplyOrderPositionState",
                schema: "ord",
                columns: table => new
                {
                    SupplayOrderPositionStateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyOrderPositionState", x => x.SupplayOrderPositionStateID);
                });

            migrationBuilder.CreateTable(
                name: "SupplyOrderState",
                schema: "ord",
                columns: table => new
                {
                    SupplayOrderStateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyOrderState", x => x.SupplayOrderStateID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                schema: "usr",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "VAT",
                schema: "bok",
                columns: table => new
                {
                    VATID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VATPercentage = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VAT", x => x.VATID);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                schema: "str",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    StorageLocationID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => new { x.ISBN, x.StorageLocationID });
                    table.ForeignKey(
                        name: "FK_Storage_StorageLocation_StorageLocationID",
                        column: x => x.StorageLocationID,
                        principalSchema: "str",
                        principalTable: "StorageLocation",
                        principalColumn: "StorageLocationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplyOrder",
                schema: "ord",
                columns: table => new
                {
                    SupplyOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplyOrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SupplierID = table.Column<int>(type: "int", nullable: false),
                    SupplyOrderStateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyOrder", x => x.SupplyOrderID);
                    table.ForeignKey(
                        name: "FK_SupplyOrder_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalSchema: "bok",
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplyOrder_SupplyOrderState_SupplyOrderStateID",
                        column: x => x.SupplyOrderStateID,
                        principalSchema: "ord",
                        principalTable: "SupplyOrderState",
                        principalColumn: "SupplayOrderStateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "usr",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    UserTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeID",
                        column: x => x.UserTypeID,
                        principalSchema: "usr",
                        principalTable: "UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                schema: "bok",
                columns: table => new
                {
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false),
                    PictureURL = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    LanguageCode = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    GenreID = table.Column<int>(type: "int", nullable: false),
                    PublisherID = table.Column<int>(type: "int", nullable: false),
                    VATID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_Book_Genre_GenreID",
                        column: x => x.GenreID,
                        principalSchema: "bok",
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Language_LanguageCode",
                        column: x => x.LanguageCode,
                        principalSchema: "bok",
                        principalTable: "Language",
                        principalColumn: "LanguageCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_Publisher_PublisherID",
                        column: x => x.PublisherID,
                        principalSchema: "bok",
                        principalTable: "Publisher",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Book_VAT_VATID",
                        column: x => x.VATID,
                        principalSchema: "bok",
                        principalTable: "VAT",
                        principalColumn: "VATID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrder",
                schema: "ord",
                columns: table => new
                {
                    CustomerOrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ZIP = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    CustomerOrderStateID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrder", x => x.CustomerOrderID);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_CustomerOrderState_CustomerOrderStateID",
                        column: x => x.CustomerOrderStateID,
                        principalSchema: "ord",
                        principalTable: "CustomerOrderState",
                        principalColumn: "CustomerOrderStateId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerOrder_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolesUser",
                schema: "usr",
                columns: table => new
                {
                    RolesRoleID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesUser", x => new { x.RolesRoleID, x.UserID });
                    table.ForeignKey(
                        name: "FK_RolesUser_Roles_RolesRoleID",
                        column: x => x.RolesRoleID,
                        principalSchema: "usr",
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesUser_User_UserID",
                        column: x => x.UserID,
                        principalSchema: "usr",
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorBook",
                schema: "bok",
                columns: table => new
                {
                    AuthorsAuthorId = table.Column<int>(type: "int", nullable: false),
                    BooksISBN = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorBook", x => new { x.AuthorsAuthorId, x.BooksISBN });
                    table.ForeignKey(
                        name: "FK_AuthorBook_Author_AuthorsAuthorId",
                        column: x => x.AuthorsAuthorId,
                        principalSchema: "bok",
                        principalTable: "Author",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorBook_Book_BooksISBN",
                        column: x => x.BooksISBN,
                        principalSchema: "bok",
                        principalTable: "Book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookDiscount",
                schema: "bok",
                columns: table => new
                {
                    BooksISBN = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    DiscountsDiscountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookDiscount", x => new { x.BooksISBN, x.DiscountsDiscountId });
                    table.ForeignKey(
                        name: "FK_BookDiscount_Book_BooksISBN",
                        column: x => x.BooksISBN,
                        principalSchema: "bok",
                        principalTable: "Book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookDiscount_Discount_DiscountsDiscountId",
                        column: x => x.DiscountsDiscountId,
                        principalSchema: "bok",
                        principalTable: "Discount",
                        principalColumn: "DiscountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSupplier",
                schema: "bok",
                columns: table => new
                {
                    BooksISBN = table.Column<string>(type: "nvarchar(13)", nullable: false),
                    SuppliersSupplierID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSupplier", x => new { x.BooksISBN, x.SuppliersSupplierID });
                    table.ForeignKey(
                        name: "FK_BookSupplier_Book_BooksISBN",
                        column: x => x.BooksISBN,
                        principalSchema: "bok",
                        principalTable: "Book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSupplier_Supplier_SuppliersSupplierID",
                        column: x => x.SuppliersSupplierID,
                        principalSchema: "bok",
                        principalTable: "Supplier",
                        principalColumn: "SupplierID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyOrderPosition",
                schema: "ord",
                columns: table => new
                {
                    SuppllyOrderID = table.Column<int>(type: "int", nullable: false),
                    SupplayOrderPositionID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    SupplyOrderPositionStateID = table.Column<int>(type: "int", nullable: false),
                    BooksISBN = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyOrderPosition", x => new { x.SupplayOrderPositionID, x.SuppllyOrderID });
                    table.ForeignKey(
                        name: "FK_SupplyOrderPosition_Book_BooksISBN",
                        column: x => x.BooksISBN,
                        principalSchema: "bok",
                        principalTable: "Book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplyOrderPosition_SupplyOrder_SuppllyOrderID",
                        column: x => x.SuppllyOrderID,
                        principalSchema: "ord",
                        principalTable: "SupplyOrder",
                        principalColumn: "SupplyOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplyOrderPosition_SupplyOrderPositionState_SupplyOrderPositionStateID",
                        column: x => x.SupplyOrderPositionStateID,
                        principalSchema: "ord",
                        principalTable: "SupplyOrderPositionState",
                        principalColumn: "SupplayOrderPositionStateID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerOrderPosition",
                schema: "ord",
                columns: table => new
                {
                    CustomerOrderPositionID = table.Column<int>(type: "int", nullable: false),
                    CustomerOrderID = table.Column<int>(type: "int", nullable: false),
                    CustomerOrderPositionStateID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    BooksISBN = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerOrderPosition", x => new { x.CustomerOrderPositionID, x.CustomerOrderID });
                    table.ForeignKey(
                        name: "FK_CustomerOrderPosition_Book_BooksISBN",
                        column: x => x.BooksISBN,
                        principalSchema: "bok",
                        principalTable: "Book",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerOrderPosition_CustomerOrder_CustomerOrderID",
                        column: x => x.CustomerOrderID,
                        principalSchema: "ord",
                        principalTable: "CustomerOrder",
                        principalColumn: "CustomerOrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerOrderPosition_CustomerOrderPositionState_CustomerOrderPositionStateID",
                        column: x => x.CustomerOrderPositionStateID,
                        principalSchema: "ord",
                        principalTable: "CustomerOrderPositionState",
                        principalColumn: "CustomerOrderPositionStateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorBook_BooksISBN",
                schema: "bok",
                table: "AuthorBook",
                column: "BooksISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Book_GenreID",
                schema: "bok",
                table: "Book",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_LanguageCode",
                schema: "bok",
                table: "Book",
                column: "LanguageCode");

            migrationBuilder.CreateIndex(
                name: "IX_Book_PublisherID",
                schema: "bok",
                table: "Book",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_VATID",
                schema: "bok",
                table: "Book",
                column: "VATID");

            migrationBuilder.CreateIndex(
                name: "IX_BookDiscount_DiscountsDiscountId",
                schema: "bok",
                table: "BookDiscount",
                column: "DiscountsDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSupplier_SuppliersSupplierID",
                schema: "bok",
                table: "BookSupplier",
                column: "SuppliersSupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_CustomerOrderStateID",
                schema: "ord",
                table: "CustomerOrder",
                column: "CustomerOrderStateID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrder_UserID",
                schema: "ord",
                table: "CustomerOrder",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderPosition_BooksISBN",
                schema: "ord",
                table: "CustomerOrderPosition",
                column: "BooksISBN");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderPosition_CustomerOrderID",
                schema: "ord",
                table: "CustomerOrderPosition",
                column: "CustomerOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerOrderPosition_CustomerOrderPositionStateID",
                schema: "ord",
                table: "CustomerOrderPosition",
                column: "CustomerOrderPositionStateID");

            migrationBuilder.CreateIndex(
                name: "IX_RolesUser_UserID",
                schema: "usr",
                table: "RolesUser",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_StorageLocationID",
                schema: "str",
                table: "Storage",
                column: "StorageLocationID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrder_SupplierID",
                schema: "ord",
                table: "SupplyOrder",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrder_SupplyOrderStateID",
                schema: "ord",
                table: "SupplyOrder",
                column: "SupplyOrderStateID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrderPosition_BooksISBN",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "BooksISBN");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrderPosition_SuppllyOrderID",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "SuppllyOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyOrderPosition_SupplyOrderPositionStateID",
                schema: "ord",
                table: "SupplyOrderPosition",
                column: "SupplyOrderPositionStateID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                schema: "usr",
                table: "User",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorBook",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "BookDiscount",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "BookSupplier",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "CustomerOrderPosition",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "RolesUser",
                schema: "usr");

            migrationBuilder.DropTable(
                name: "Storage",
                schema: "str");

            migrationBuilder.DropTable(
                name: "SupplyOrderPosition",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "Author",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "Discount",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "CustomerOrder",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "CustomerOrderPositionState",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "usr");

            migrationBuilder.DropTable(
                name: "StorageLocation",
                schema: "str");

            migrationBuilder.DropTable(
                name: "Book",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "SupplyOrder",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "SupplyOrderPositionState",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "CustomerOrderState",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "User",
                schema: "usr");

            migrationBuilder.DropTable(
                name: "Genre",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "Language",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "Publisher",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "VAT",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "Supplier",
                schema: "bok");

            migrationBuilder.DropTable(
                name: "SupplyOrderState",
                schema: "ord");

            migrationBuilder.DropTable(
                name: "UserType",
                schema: "usr");
        }
    }
}
