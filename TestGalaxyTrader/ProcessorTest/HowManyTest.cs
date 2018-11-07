using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GalaxyTrader;

namespace TestGalaxyTrader.ProcessorTest
{
    [TestClass]
    public class HowManyTest
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
            qg.Query(context, "zeus is c");

            qg.Query(context, "glob glob Silver is 34 Credits");
            qg.Query(context, "glob prok Gold is 57800 Credits");
            qg.Query(context, "pish pish Iron is 3910 Credits");
            qg.Query(context, "pish pish glob glob glob copper is 1127 credits");
        }

        [TestMethod]
        public void ValidQuery()
        {
            float val = qg.Query(context, "how many Credits is glob prok Gold ?");

            Assert.IsTrue(val == 57800);
        }

        [TestMethod]
        public void FloatTest()
        {
            float val = qg.Query(context, "how many Credits is glob prok Iron ?");

            Assert.IsTrue(val == 782);
        }
    }
}
