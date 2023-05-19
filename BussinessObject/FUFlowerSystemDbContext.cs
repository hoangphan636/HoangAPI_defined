using BusinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class FUFlowerSystemDbContext:DbContext
    {
        public FUFlowerSystemDbContext()
        {
        }

        public Customer getDefaultAccounts()
        {
            var admin = new Customer();
            IConfiguration config = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", true, true)
                        .Build();
            
            admin.CustomerName = "ADMIN";
            admin.Email = config["Credentials:Email"];
            admin.password = config["Credentials:Password"];

            return admin;

        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];

            return strConn;
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<FlowerBouquet> FlowerBouquet { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {




            optionsBuilder.UseSqlServer(GetConnectionString());

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<OrderDetail>()
                   .HasKey(od => new { od.OrderID, od.FlowerBouquetID });

            // Other configurations...

            base.OnModelCreating(modelBuilder);


        }

    }
}
