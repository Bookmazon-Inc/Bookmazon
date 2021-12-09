﻿// <auto-generated />
using System;
using Bookmazon.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookmazon.Server.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20211209144654_changed Storage Model")]
    partial class changedStorageModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<int>("AuthorsAuthorId")
                        .HasColumnType("int");

                    b.Property<string>("BooksISBN")
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("AuthorsAuthorId", "BooksISBN");

                    b.HasIndex("BooksISBN");

                    b.ToTable("AuthorBook", "bok");
                });

            modelBuilder.Entity("BookDiscount", b =>
                {
                    b.Property<string>("BooksISBN")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("DiscountsDiscountId")
                        .HasColumnType("int");

                    b.HasKey("BooksISBN", "DiscountsDiscountId");

                    b.HasIndex("DiscountsDiscountId");

                    b.ToTable("BookDiscount", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuthorId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Firstname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Penname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AuthorId");

                    b.ToTable("Author", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int>("GenreID")
                        .HasColumnType("int");

                    b.Property<string>("LanguageCode")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("PictureURL")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("PublisherID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<int>("VATID")
                        .HasColumnType("int");

                    b.HasKey("ISBN");

                    b.HasIndex("GenreID");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("PublisherID");

                    b.HasIndex("VATID");

                    b.ToTable("Book", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrder", b =>
                {
                    b.Property<int>("CustomerOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerOrderID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("CustomerOrderStateID")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("ZIP")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("CustomerOrderID");

                    b.HasIndex("CustomerOrderStateID");

                    b.HasIndex("UserID");

                    b.ToTable("CustomerOrder", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrderPosition", b =>
                {
                    b.Property<int>("CustomerOrderPositionID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerOrderID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BooksISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("CustomerOrderPositionStateID")
                        .HasColumnType("int");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.HasKey("CustomerOrderPositionID", "CustomerOrderID");

                    b.HasIndex("BooksISBN");

                    b.HasIndex("CustomerOrderID");

                    b.HasIndex("CustomerOrderPositionStateID");

                    b.ToTable("CustomerOrderPosition", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrderPositionState", b =>
                {
                    b.Property<int>("CustomerOrderPositionStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerOrderPositionStateId"), 1L, 1);

                    b.Property<string>("Notes")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerOrderPositionStateId");

                    b.ToTable("CustomerOrderPositionState", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrderState", b =>
                {
                    b.Property<int>("CustomerOrderStateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerOrderStateId"), 1L, 1);

                    b.Property<string>("Notes")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CustomerOrderStateId");

                    b.ToTable("CustomerOrderState", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"), 1L, 1);

                    b.Property<string>("DiscountName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("DiscountPercentage")
                        .HasColumnType("int");

                    b.Property<decimal?>("DiscountValue")
                        .HasColumnType("decimal(18,4)");

                    b.Property<DateTime>("Enddate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("datetime2");

                    b.HasKey("DiscountId");

                    b.ToTable("Discount", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"), 1L, 1);

                    b.Property<string>("Notes")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenreId");

                    b.ToTable("Genre", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Language", b =>
                {
                    b.Property<string>("LanguageCode")
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("LanguageCode");

                    b.ToTable("Language", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PublisherId"), 1L, 1);

                    b.Property<string>("PublisherName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Roles", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"), 1L, 1);

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles", "usr");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Storage", b =>
                {
                    b.Property<string>("ISBN")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("StorageLocationID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("ISBN", "StorageLocationID");

                    b.HasIndex("StorageLocationID");

                    b.ToTable("Storage", "str");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.StorageLocation", b =>
                {
                    b.Property<int>("StorageLocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StorageLocationID"), 1L, 1);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("StorageLocationID");

                    b.ToTable("StorageLocation", "str");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierID"), 1L, 1);

                    b.Property<string>("Notes")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SupplierID");

                    b.ToTable("Supplier", "bok");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrder", b =>
                {
                    b.Property<int>("SupplyOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplyOrderID"), 1L, 1);

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("SupplierID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SupplyOrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SupplyOrderStateID")
                        .HasColumnType("int");

                    b.HasKey("SupplyOrderID");

                    b.HasIndex("SupplierID");

                    b.HasIndex("SupplyOrderStateID");

                    b.ToTable("SupplyOrder", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrderPosition", b =>
                {
                    b.Property<int>("SupplayOrderPositionID")
                        .HasColumnType("int");

                    b.Property<int>("SuppllyOrderID")
                        .HasColumnType("int");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("BooksISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,4)");

                    b.Property<int>("SupplyOrderPositionStateID")
                        .HasColumnType("int");

                    b.HasKey("SupplayOrderPositionID", "SuppllyOrderID");

                    b.HasIndex("BooksISBN");

                    b.HasIndex("SuppllyOrderID");

                    b.HasIndex("SupplyOrderPositionStateID");

                    b.ToTable("SupplyOrderPosition", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrderPositionState", b =>
                {
                    b.Property<int>("SupplayOrderPositionStateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplayOrderPositionStateID"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SupplayOrderPositionStateID");

                    b.ToTable("SupplyOrderPositionState", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrderState", b =>
                {
                    b.Property<int>("SupplayOrderStateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplayOrderStateID"), 1L, 1);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SupplayOrderStateID");

                    b.ToTable("SupplyOrderState", "ord");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("nvarchar(32)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.HasIndex("UserTypeID");

                    b.ToTable("User", "usr");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserTypeID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserType", "usr");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.VAT", b =>
                {
                    b.Property<int>("VATID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VATID"), 1L, 1);

                    b.Property<int>("VATPercentage")
                        .HasColumnType("int");

                    b.HasKey("VATID");

                    b.ToTable("VAT", "bok");
                });

            modelBuilder.Entity("BookSupplier", b =>
                {
                    b.Property<string>("BooksISBN")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int>("SuppliersSupplierID")
                        .HasColumnType("int");

                    b.HasKey("BooksISBN", "SuppliersSupplierID");

                    b.HasIndex("SuppliersSupplierID");

                    b.ToTable("BookSupplier", "bok");
                });

            modelBuilder.Entity("RolesUser", b =>
                {
                    b.Property<int>("RolesRoleID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("RolesRoleID", "UserID");

                    b.HasIndex("UserID");

                    b.ToTable("RolesUser", "usr");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsAuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookDiscount", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.Discount", null)
                        .WithMany()
                        .HasForeignKey("DiscountsDiscountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Book", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.Language", "Language")
                        .WithMany("Books")
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.VAT", "VAT")
                        .WithMany("Books")
                        .HasForeignKey("VATID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Language");

                    b.Navigation("Publisher");

                    b.Navigation("VAT");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrder", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.CustomerOrderState", "CustomerOrderState")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("CustomerOrderStateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.User", "User")
                        .WithMany("CustomerOrders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CustomerOrderState");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrderPosition", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Book", "Books")
                        .WithMany("CustomerOrderPositions")
                        .HasForeignKey("BooksISBN")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.CustomerOrder", "CustomerOrder")
                        .WithMany("CustomerOrderPositions")
                        .HasForeignKey("CustomerOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.CustomerOrderPositionState", "CustomerOrderPositionState")
                        .WithMany("CustomerOrderPositions")
                        .HasForeignKey("CustomerOrderPositionStateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("CustomerOrder");

                    b.Navigation("CustomerOrderPositionState");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Storage", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Book", "Book")
                        .WithMany("Storage")
                        .HasForeignKey("ISBN")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.StorageLocation", "StorageLocation")
                        .WithMany("Storage")
                        .HasForeignKey("StorageLocationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("StorageLocation");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrder", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Supplier", "Supplier")
                        .WithMany("SupplyOrders")
                        .HasForeignKey("SupplierID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.SupplyOrderState", "SupplyOrderState")
                        .WithMany("SupplyOrders")
                        .HasForeignKey("SupplyOrderStateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("SupplyOrderState");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrderPosition", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Book", "Books")
                        .WithMany("SupplyOrderPositions")
                        .HasForeignKey("BooksISBN")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.SupplyOrder", "SupplyOrder")
                        .WithMany("SupplyOrderPositions")
                        .HasForeignKey("SuppllyOrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.SupplyOrderPositionState", "SupplyOrderPositionState")
                        .WithMany("SupplyOrderPositions")
                        .HasForeignKey("SupplyOrderPositionStateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Books");

                    b.Navigation("SupplyOrder");

                    b.Navigation("SupplyOrderPositionState");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.User", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.UserType", "UserType")
                        .WithMany()
                        .HasForeignKey("UserTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("BookSupplier", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksISBN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.Supplier", null)
                        .WithMany()
                        .HasForeignKey("SuppliersSupplierID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RolesUser", b =>
                {
                    b.HasOne("Bookmazon.Shared.Models.Roles", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookmazon.Shared.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Book", b =>
                {
                    b.Navigation("CustomerOrderPositions");

                    b.Navigation("Storage");

                    b.Navigation("SupplyOrderPositions");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrder", b =>
                {
                    b.Navigation("CustomerOrderPositions");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrderPositionState", b =>
                {
                    b.Navigation("CustomerOrderPositions");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.CustomerOrderState", b =>
                {
                    b.Navigation("CustomerOrders");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Language", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.StorageLocation", b =>
                {
                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.Supplier", b =>
                {
                    b.Navigation("SupplyOrders");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrder", b =>
                {
                    b.Navigation("SupplyOrderPositions");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrderPositionState", b =>
                {
                    b.Navigation("SupplyOrderPositions");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.SupplyOrderState", b =>
                {
                    b.Navigation("SupplyOrders");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.User", b =>
                {
                    b.Navigation("CustomerOrders");
                });

            modelBuilder.Entity("Bookmazon.Shared.Models.VAT", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
