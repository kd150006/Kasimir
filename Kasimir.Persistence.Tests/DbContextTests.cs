using Kasimir.Core;
using Kasimir.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task DBContext_01_ImportCsv_ShouldReturn24ProductsWithSerialNumbersAndStocks()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var products = ImportController.ReadProductsFromCsv().ToList();
                await uow.ProductRepository.AddRange(products);
                await uow.Save();
            }
        }
    }
}
