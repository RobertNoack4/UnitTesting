using NUnit.Framework;

namespace TestNinja.UnitTest
{
    [TestFixture]
    class MathTests
    {
        private Fundamentals.Math math;
        [SetUp]
        public void SetUp()
        {
            math = new Fundamentals.Math();
        }
        [Test]
        //[Ignore("Mag ich nicht")]
        public void Add_WhenCalled_ReturnTheSumOfArguments()
        {
            var result = math.Add(1, 2);

            Assert.That(result, Is.EqualTo(3));
        }

        [Test]
        [TestCase(2, 1, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(1, 1, 1)]
        public void Max_WhenCalled_ReturnGreaterArgument(int a, int b, int expectedResult)
        {
            var result = math.Max(a, b);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetOddNumbers_LimitIsGreaterThanZero_ReturnOddNumbersUpToLimit()
        {
            var result = math.GetOddNumbers(5);

            Assert.That(result, Is.EquivalentTo(new[] { 1, 3, 5 }));
        }
    }
}
