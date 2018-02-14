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
            dbContext.Database.EnsureCreated();

            using (UnitOfWork uow = new UnitOfWork())
            {
                var productTypes = ImportController.ReadProductTypesFromCsv().ToList();
                uow.ProductTypeRepository.AddRange(productTypes);
                uow.Save();
            }
        }

        [TestMethod]
        public void DBContext_01_ImportCsv_ShouldReturn24ProductTypes()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var productTypes = uow.ProductTypeRepository.GetAll();
                Assert.AreEqual(24, productTypes.Count());
            }
        }

        [TestMethod]
        public void DBContext_02_ImportCsv_ShouldReturn1ProductTypeWithCorrectProductTypeNumber()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var productTypes = uow.ProductTypeRepository.GetByName("Google Nexus 5X Black 32 GB");
                Assert.AreEqual(1, productTypes.Count());
                var productTypeNumber = productTypes.Select(pt => pt.Number).ToArray();
                Assert.AreEqual("GOONEX5XBK32", productTypeNumber[0]);
            }
        }
        [TestMethod]
        public void DBContext_03_ImportCsv_ShouldReturn1ProdcutWithCorrectSerialNumber()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var products = uow.ProductRepository.GetBySerialNumber("338000000000000").ToArray();
                Assert.AreEqual(1, products.Count());
                var productTypeName = products.Select(product => product.ProductType.Name).ToArray();
                Assert.AreEqual("Nokia 3 Silver 16 GB", productTypeName[0]);
            }
        }
        //[TestMethod]
        //public void Basket_01_AddProductToBasket_ShouldReturnCorrectAmountOfDetails()
        //{
        //    using (UnitOfWork uow = new UnitOfWork())
        //    {
        //        var basket = new BasketHeader();
        //        var products = uow
        //            .ProductRepository
        //            .GetBySerialNumber("508000000000000")
        //            .Select(selectedProduct => new BasketDetail
        //            {
        //                ProductId = selectedProduct.Id,
        //                StockId = selectedProduct.StockId,
        //                Quantity = 1,
        //            })
        //            .ToList();

        //        basket.SumTotal = 0.0;

        //        foreach (var product in products)
        //        {
        //            basket.BasketDetails.Add(product);                    
        //        }

        //        Assert.AreEqual(1, basket.BasketDetails.Count());
        //    }
        //}
        //[TestMethod]
        //public void Basket_02_AddProductToBasket_SaveToDatabase_ShouldReturnCorrectHeaderAndDetails()
        //{
        //    using (UnitOfWork uow = new UnitOfWork())
        //    {
        //        var basket = new BasketHeader();
        //        var products = uow
        //            .ProductRepository
        //            .GetBySerialNumber("508000000000000")
        //            .Select(selectedProduct => new BasketDetail
        //            {
        //                ProductId = selectedProduct.Id,
        //                StockId = selectedProduct.Stock.Id,
        //                Quantity = 1,
        //            })
        //            .ToList();

        //        foreach (var product in products)
        //        {
        //            basket.BasketDetails.Add(product);
        //        }

        //        uow.BasketHeaderRepository.Add(basket);
        //        uow.Save();
        //    }

        //    using (UnitOfWork uow = new UnitOfWork())
        //    {
        //        var savedBasket = uow.BasketHeaderRepository.GetAll();
        //        Assert.AreEqual(1, savedBasket.Count());
        //    }
        //}
    }
}
