using Microsoft.VisualStudio.TestTools.UnitTesting;
using zadanie_1;

namespace zadanie_1.Tests
{
    [TestClass()]
    public class RationalTests
    {
        [TestMethod()]
        public void FirstRationalTest()
        {
            Rational first = new Rational(2, 3);
            Assert.IsTrue(first.ToString() == "2/3");
        }
        [TestMethod()]
        public void SecondRationalTest()
        {
            Rational first = new Rational(2, 5);
            Rational second = new Rational(7, 3);
            Assert.IsTrue((first * second) == new Rational(14, 15));
        }
        [TestMethod()]
        public void ThirdRationalTest()
        {
            Rational first = new Rational(5, 3);
            Rational second = new Rational(6, 9);
            Assert.IsTrue(first > second);
        }
    }
}
