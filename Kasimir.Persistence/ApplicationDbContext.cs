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
        public DbSet<CashDrawer> CashDrawers { get; set; }      
        public DbSet<User> Users { get; set; }        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);

            var log = new LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }
    }
}
