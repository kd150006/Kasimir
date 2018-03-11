using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kasimir.Core;
using System.Linq;

namespace Kasimir.Core.Tests
{
    [TestClass]
    public class ImportControllerTests
    {
        [TestMethod]
        public void ImportController_001_ShouldReturn24ProductTypes()
        {
            var products = ImportController.ReadProductsFromCsv();
            Assert.AreEqual(24, products.Count());
        }
    }
}
