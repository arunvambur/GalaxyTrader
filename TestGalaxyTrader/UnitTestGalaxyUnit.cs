using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaxyTrader;

namespace TestGalaxyTrader
{
    [TestClass]
    public class UnitTestGalaxyUnit
    {
        [TestMethod]
        public void EmptyTest()
        {
            GalacticUnit gu = new GalacticUnit();

            Assert.IsTrue(string.IsNullOrEmpty(gu.Value));
        }

        [TestMethod]
        public void ValidTest()
        {
            GalacticUnit gu = new GalacticUnit("XXLV");

            Assert.IsFalse(string.IsNullOrEmpty(gu.Value));
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void InValidTest()
        {
            GalacticUnit gu = new GalacticUnit("lsakdjf");
        }

        [TestMethod]
        public void ArabicTest()
        {
            GalacticUnit gu = new GalacticUnit("MCMXLIV");

            int arabicVal = gu.ToArabic();

            Assert.AreEqual<int>(arabicVal, 1944);
        }

        [TestMethod]
        public void BoundaryArabicTest()
        {
            GalacticUnit gu = new GalacticUnit("MMMCMXCIX");

            int arabicVal = gu.ToArabic();

            Assert.AreEqual<int>(arabicVal, 3999);
        }

        [TestMethod]
        public void ZeroArabicTest()
        {
            GalacticUnit gu = new GalacticUnit();

            int arabicVal = gu.ToArabic();

            Assert.AreEqual<int>(arabicVal, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GreaterThanFourThousandTest()
        {
            GalacticUnit gu = new GalacticUnit(4500);
        }

        [TestMethod]
        public void ToGalactivTest()
        {
            GalacticUnit gu = new GalacticUnit(1944);

            Assert.AreEqual<string>(gu.Value, "MCMXLIV");
        }

        [TestMethod]
        public void ToGalactivBoundaryTest()
        {
            GalacticUnit gu = new GalacticUnit(3999);

            Assert.AreEqual<string>(gu.Value, "MMMCMXCIX");
        }

        [TestMethod]
        public void AdditionTest()
        {
            GalacticUnit a = new GalacticUnit("X"); //10
            GalacticUnit b = new GalacticUnit("V"); //5
            GalacticUnit gu = a + b;

            Assert.AreEqual<long>(gu.ToArabic(), 15);
            Assert.AreEqual<string>(gu.Value, "XV");
        }

        [TestMethod]
        public void SubtractionTest()
        {
            GalacticUnit a = new GalacticUnit("X"); //10
            GalacticUnit b = new GalacticUnit("V"); //5
            GalacticUnit gu = a - b;

            Assert.AreEqual<long>(gu.ToArabic(), 5);
            Assert.AreEqual<string>(gu.Value, "V");
        }

        [TestMethod]
        public void MultiplicationTest()
        {
            GalacticUnit a = new GalacticUnit("X"); //10
            GalacticUnit b = new GalacticUnit("V"); //5
            GalacticUnit gu = a * b;

            Assert.AreEqual<long>(gu.ToArabic(), 50);
            Assert.AreEqual<string>(gu.Value, "L");
        }

        [TestMethod]
        public void DivisionTest()
        {
            GalacticUnit a = new GalacticUnit("X"); //10
            GalacticUnit b = new GalacticUnit("V"); //5
            GalacticUnit gu = a / b;

            Assert.AreEqual<long>(gu.ToArabic(), 2);
            Assert.AreEqual<string>(gu.Value, "II");
        }
    }
}
