using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTest
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnTrue()
        {
            // Arrange
            var reservation = new Reservation();

            // Act
            var result = reservation.CanBeCancelledBy(new User { IsAdmin = true });

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnTrue()
        {
            var reservation = new Reservation();
            User test = new User();
            reservation.MadeBy = test;

            var result = reservation.CanBeCancelledBy(test);

            Assert.That(result, Is.True);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnFalse()
        {
            var reservation = new Reservation();

            var result = reservation.CanBeCancelledBy(new User());

            Assert.That(result, Is.False);
        }
    }
}
