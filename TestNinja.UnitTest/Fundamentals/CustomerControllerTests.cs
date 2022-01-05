using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    class CustomerControllerTests
    {
        private CustomerController controller;
        [SetUp]
        public void SetUp()
        {
            controller = new CustomerController();
        }

        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var result = controller.GetCustomer(0);

            Assert.That(result, Is.TypeOf<NotFound>());

            //Result should be "NotFound" or one of its derivatives
            //Assert.That(result, Is.InstanceOf<NotFound>()); 
        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var result = controller.GetCustomer(1);
            Assert.That(result, Is.TypeOf<Ok>());
        }

    }
}
