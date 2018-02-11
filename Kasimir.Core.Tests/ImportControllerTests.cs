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
            var productTypes = ImportController.ReadProductTypesFromCsv();
            Assert.AreEqual(24, productTypes.Count());
        }
    }
}
