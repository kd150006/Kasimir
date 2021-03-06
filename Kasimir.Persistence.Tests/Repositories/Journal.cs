﻿using Kasimir.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kasimir.Persistence.Tests
{
    [TestClass]
    public class Journal
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
        public void JournalRepo_001_GetByTransactionTypePurchase_ShouldReturn1Transaction()
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var pruchaseJournals = uow.JournalRepository.GetByTransactionType(true, false, false, false).ToList();
                Assert.AreEqual(0, pruchaseJournals.Count());
            }
        }
    }
}
