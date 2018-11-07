using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GalaxyTrader;

namespace TestGalaxyTrader.ProcessorTest
{
    [TestClass]
    public class HowMuchTest
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
            float val = qg.Query(context, "how much is pish tegj glob glob ?");

            Assert.IsTrue(val == 42);
        }

        [TestMethod]
        public void BigNumber()
        {
            float val = qg.Query(context, "how much is zeus zeus zeus glob glob ?");

            Assert.IsTrue(val == 302);
        }

        [TestMethod]
        public void LongVariables()
        {
            float val = qg.Query(context, "how much is zeus zeus zeus zeus zeus zeus zeus ?");

            Assert.IsTrue(val == 700);
        }
    }
}
