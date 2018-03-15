using Kasimir.Core;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kasimir.Persistence.Tests
{
    [TestClass]
    public class DbContextTests
    {
        [TestInitialize]
        public void Initialize()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            dbContext.Database.EnsureDeleted();
            dbContext.Database.Migrate();
        }

        [TestMethod]
        public void DBContext_01_ImportCsv_ShouldReturn24ProductsWithSerialNumbersAndStocks()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var products = ImportController.ReadProductsFromCsv().ToList();
                uow.ProductRepository.AddRange(products);
                uow.Save();
            }
        }
    }
}
