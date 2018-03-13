using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;

namespace Kasimir.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }    
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<BasketDetail> BasketDetails { get; set; }
        public DbSet<BasketHeader> BasketHeaders { get; set; }        
        public DbSet<Journal> Journals { get; set; }
        public DbSet<CashDrawer> CashDrawers { get; set; }
        public DbSet<MeansOfPayment> MeansOfPayments { get; set; }        
        public DbSet<User> Users { get; set; }        
        public DbSet<SerialNumber> SerialNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            //string connectionString = configuration["ConnectionStrings:DefaultConnection"];
            //optionsBuilder.UseSqlServer(connectionString);

            //var log = new LoggerConfiguration()
            //    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
            //    .CreateLogger();

            /* MySQL */
            string connectionString = configuration["ConnectionStrings:MySQLConnection"];
            optionsBuilder.UseMySQL(connectionString);
                //UseMySql(connectionString);
            /* Pomelo MySql */
            //string connectionString = configuration["ConnectionStrings:PomeloMySqlConnection"];
            //optionsBuilder.UseMySql(connectionString);
        }
    }
}
