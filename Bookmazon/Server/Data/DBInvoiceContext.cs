using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookmazon.Shared.Models;

namespace Bookmazon.Server.Data
{
    public class DBInvoiceContext : DbContext
    {
        public DBInvoiceContext (DbContextOptions<DBInvoiceContext> options)
            : base(options)
        {
        }

        public DbSet<Invoice> Invoices { get; set;}
        public DbSet<InvoicePosition> InvoicePositions { get; set;}
        public DbSet<InvoiceState> InvoiceStates { get; set;}

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            //Multiple Primary Keys
            modelbuilder.Entity<InvoicePosition>().HasKey(k => new { k.InvoicePositionID, k.InvoiceID });

            //Cascade Behaviour
            modelbuilder.Entity<Invoice>().HasOne(s => s.InvoiceState).WithMany(s => s.Invoices).OnDelete(DeleteBehavior.Restrict);
            modelbuilder.Entity<InvoicePosition>().HasOne(s => s.Invoices).WithMany(s => s.InvoicePositions).OnDelete(DeleteBehavior.Restrict);

            //Setting Schema

            //Invoice Schema
            modelbuilder.Entity<Invoice>().ToTable("Invoice", "inv");
            modelbuilder.Entity<InvoicePosition>().ToTable("InvoicePosition", "inv");
            modelbuilder.Entity<InvoiceState>().ToTable("InvoiceState", "inv");


        }
    }
}
