using Kasimir.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Tests
{
    [TestClass]
    public class Product
    {


        [TestInitialize]
        public void Initialize()
        {
            //ApplicationDbContext dbContext = new ApplicationDbContext();
            //dbContext.Database.EnsureDeleted();
            //dbContext.Database.Migrate();
            //dbContext.Database.EnsureCreated();

            //using (UnitOfWork uow = new UnitOfWork())
            //{
            //    var productTypes = ImportController.ReadProductTypesFromCsv().ToList();
            //    uow.ProductTypeRepository.AddRange(productTypes);
            //    uow.Save();
            //}
        }

        [TestMethod]
        public void ProductRepoTest_001_GetAllProductsWithProductTypes_ShouldReturn20ProductsWithDetails()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var products = uow.ProductRepository.GetAll();
                Assert.AreEqual(20, products.Count());
            }
        }
    }
}
