using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GalaxyTrader;

namespace TestGalaxyTrader.ProcessorTest
{
    [TestClass]
    public class VariableAssignmentTest
    {
        IContext context = new StorageContext();
        IQueryGalaxy qg = new QueryGalaxy();

        [TestMethod]
        public void TestIsAssignment()
        {
            float val = qg.Query(context, "glob is I");

            Assert.IsTrue(val == 1);
        }

        [TestMethod]
        public void TestIsAssignmentSmallcase()
        {
            float val = qg.Query(context, "glob is i");

            Assert.IsTrue(val == 1);
        }

        [TestMethod]
        public void TestReAssignment()
        {
            float val = qg.Query(context, "glob is i");

            Assert.IsTrue(val == 1);

            qg.Query(context, "glob is c");
        }

        [TestMethod]
        [ExpectedException(typeof(QueryGalaxyException))]
        public void TestIsWrongGalacticUnit()
        {
            float val = qg.Query(context, "glob is Z");
            
        }

        [TestMethod]
        [ExpectedException(typeof(QueryGalaxyException))]
        public void TestWrongQuery()
        {
            float val = qg.Query(context, "glob = i");

            Assert.IsTrue(val == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(QueryGalaxyException))]
        public void TestTwoVariableDefinition()
        {
            float val = qg.Query(context, "glob glob is i");

            Assert.IsTrue(val == 1);
        }


    }
}
