using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookmazon.Shared.Models;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace Bookmazon.Server.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderPosition> CustomerOrderPositions { get; set; }
        public DbSet<CustomerOrderPositionState> CustomerOrderPositionStates { get; set; }
        public DbSet<CustomerOrderState> CustomerOrderStates { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Storage> Storages { get; set; }
        public DbSet<StorageLocation> StorageLocations { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplyOrder> SupplyOrders { get; set; }
        public DbSet<SupplyOrderState> SupplyOrderStates { get; set; }
        public DbSet<SupplyOrderPosition> SupplyOrderPositions { get; set;}
        public DbSet<SupplyOrderPositionState> SupplyOrderPositionStates { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<VAT> VAT { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            #region Settings
            //Unique Restrictions
            modelbuilder.Entity<User>().HasAlternateKey(a => new {a.UserName, a.Email});

            //Multiple Primary Keys
            modelbuilder.Entity<Storage>().HasKey(k => new { k.ISBN, k.StorageLocationID });
            modelbuilder.Entity<SupplyOrderPosition>().HasKey(k => new { k.SupplyOrderPositionID, k.SupplyOrderID });
            modelbuilder.Entity<CustomerOrderPosition>().HasKey(k => new { k.CustomerOrderPositionID, k.CustomerOrderID });

            //Cascade Restrictions
            modelbuilder.Entity<Storage>().HasOne(s => s.StorageLocation).WithMany(s => s.Storage).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Storage>().HasOne(s => s.Book).WithMany(s => s.Storage).OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<SupplyOrder>().HasOne(s => s.Supplier).WithMany(s => s.SupplyOrders).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<SupplyOrder>().HasOne(s => s.SupplyOrderState).WithMany(s => s.SupplyOrders).OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<CustomerOrder>().HasOne(s => s.CustomerOrderState).WithMany(s => s.CustomerOrders).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<CustomerOrder>().HasOne(s => s.User).WithMany(s => s.CustomerOrders).OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<Book>().HasOne(s => s.Genre).WithMany(s => s.Books).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Book>().HasOne(s => s.Language).WithMany(s => s.Books).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Book>().HasOne(s => s.Publisher).WithMany(s => s.Books).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<Book>().HasOne(s => s.VAT).WithMany(s => s.Books).OnDelete(DeleteBehavior.Restrict);
            
            modelbuilder.Entity<SupplyOrderPosition>().HasOne(s => s.SupplyOrderPositionState).WithMany(s => s.SupplyOrderPositions).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<SupplyOrderPosition>().HasOne(s => s.Book).WithMany(s => s.SupplyOrderPositions).OnDelete(DeleteBehavior.Restrict);

            modelbuilder.Entity<CustomerOrderPosition>().HasOne(s => s.CustomerOrderPositionState).WithMany(s => s.CustomerOrderPositions).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<CustomerOrderPosition>().HasOne(s => s.Books).WithMany(s => s.CustomerOrderPositions).OnDelete(DeleteBehavior.Restrict);

            //Setting Schema

            //Book Schema
            modelbuilder.Entity<Author>().ToTable("Author", "bok");
            modelbuilder.Entity<Book>().ToTable("Book", "bok");
            modelbuilder.Entity<Discount>().ToTable("Discount", "bok");
            modelbuilder.Entity<Genre>().ToTable("Genre", "bok");
            modelbuilder.Entity<Language>().ToTable("Language", "bok");
            modelbuilder.Entity<Publisher>().ToTable("Publisher", "bok");
            modelbuilder.Entity<Supplier>().ToTable("Supplier", "bok");
            modelbuilder.Entity<VAT>().ToTable("VAT", "bok");

            //Order Schema
            modelbuilder.Entity<CustomerOrder>().ToTable("CustomerOrder", "ord");
            modelbuilder.Entity<CustomerOrderPosition>().ToTable("CustomerOrderPosition", "ord");
            modelbuilder.Entity<CustomerOrderPositionState>().ToTable("CustomerOrderPositionState", "ord");
            modelbuilder.Entity<CustomerOrderState>().ToTable("CustomerOrderState", "ord");
            modelbuilder.Entity<SupplyOrder>().ToTable("SupplyOrder", "ord");
            modelbuilder.Entity<SupplyOrderPosition>().ToTable("SupplyOrderPosition", "ord");
            modelbuilder.Entity<SupplyOrderPositionState>().ToTable("SupplyOrderPositionState", "ord");
            modelbuilder.Entity<SupplyOrderState>().ToTable("SupplyOrderState", "ord");

            //Storage Schema
            modelbuilder.Entity<Storage>().ToTable("Storage", "str");
            modelbuilder.Entity<StorageLocation>().ToTable("StorageLocation", "str");

            //User Schema
            modelbuilder.Entity<Roles>().ToTable("Roles", "usr");
            modelbuilder.Entity<User>().ToTable("User", "usr");
            #endregion
        }
    }
}
