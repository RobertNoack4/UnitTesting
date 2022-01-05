using TestNinja.Fundamentals;
using NUnit.Framework;

namespace TestNinja.UnitTest
{
    [TestFixture]
    class FizzBuzzTests
    {
        [Test]
        public void GetOutPut_NumberDivisibleBy3And5_ReturnFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);

            Assert.That(result, Is.EqualTo(("FizzBuzz")));
        }

        [Test]
        public void GetOutPut_NumberDivisibleBy3Only_ReturnFizz()
        {
            var result = FizzBuzz.GetOutput(6);

            Assert.That(result, Is.EqualTo(("Fizz")));
        }

        [Test]
        public void GetOutPut_NumberDivisibleBy5Only_ReturnBuzz()
        {
            var result = FizzBuzz.GetOutput(10);

            Assert.That(result, Is.EqualTo(("Buzz")));
        }

        [Test]
        public void GetOutPut_NumberNotDivisibleBy3Or5_ReturnInputNumberAsString()
        {
            var result = FizzBuzz.GetOutput(7);

            Assert.That(result, Is.EqualTo(("7")));
        }
    }
}
