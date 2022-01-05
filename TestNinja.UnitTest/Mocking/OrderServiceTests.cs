using TestNinja.Mocking;
using NUnit.Framework;
using Moq;

namespace TestNinja.UnitTest.Mocking
{
    [TestFixture]
    class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreOrder()
        {
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);
            var order = new Order();

            service.PlaceOrder(order);

            storage.Verify(s => s.Store(order));
        }
    }
}
