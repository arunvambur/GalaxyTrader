using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GalaxyTrader;

namespace TestGalaxyTrader.ProcessorTest
{
    [TestClass]
    public class CreditAssignmentTest
    {
        IContext context = new StorageContext();
        IQueryGalaxy qg = new QueryGalaxy();

        [TestInitialize]
        public void Initialize()
        {
            float val = qg.Query(context, "glob is I");
            qg.Query(context, "prok is v");
            qg.Query(context, "pish is x");
            qg.Query(context, "tegj is L");
        }

        [TestMethod]
        public void CreditAssignmentStatement()
        {
            float val = qg.Query(context, "glob glob Silver is 34 Credits");

            Assert.IsTrue(val == 17);
        }

        [TestMethod]
        [ExpectedException(typeof(QueryGalaxyException))]
        public void TestCaseSensitive()
        {
            float val = qg.Query(context, "GLOB GLOB Silver is 34 Credits");
        }

        [TestMethod]
        public void TestMultiVariable()
        {
            float val = qg.Query(context, "pish tegj glob glob Silver is 420 Credits");

            Assert.IsTrue(val == 10);
        }

        [TestMethod]
        public void TestFraction()
        {
            float val = qg.Query(context, "pish pish Iron is 3910 Credits");

            Assert.IsTrue(val == 195.5);
        }

        [TestMethod]
        [ExpectedException(typeof(QueryGalaxyException))]
        public void TestInvalidQuery()
        {
            float val = qg.Query(context, "glob glob Silver 34 Credits");
        }

        [TestMethod]
        [ExpectedException(typeof(QueryGalaxyException))]
        public void TestNoCreditVariable()
        {
            float val = qg.Query(context, "glob glob is 34 Credits");
        }
    }
}
