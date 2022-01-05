using System;
using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTest
{
    [TestFixture]
    class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase (-1)]
        [TestCase (301)]
        public void CalculateDemeritPoints_InputLessThanZeroOrOver300_OutOfRangeException(int test)
        {
            var calculator = new DemeritPointsCalculator();


            Assert.That(() => calculator.CalculateDemeritPoints(test), Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void CalculateDemeritPoints_InputGreaterThenZeroButLessThenSpeedLimit_Return0()
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(10);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void CalculateDemeritPoints_InputGreaterThenSpeedLimit_Return1PointEvery5OverSpeedLimit()
        {
            var calculator = new DemeritPointsCalculator();

            var result = calculator.CalculateDemeritPoints(75);

            Assert.That(result, Is.EqualTo(2));
        }
    }
}
