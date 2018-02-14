using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kasimir.Core.Tests
{
    [TestClass]
    public class AutoMapperTests
    {
        [TestMethod]
        public void AutoMapper_001_Foo()
        {
            var config = AutoMapperConfiguration.Configure();

            config.AssertConfigurationIsValid();
        }
    }
}
