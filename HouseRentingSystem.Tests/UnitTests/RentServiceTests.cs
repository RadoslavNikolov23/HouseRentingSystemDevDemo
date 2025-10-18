using HouseRentingSystem.Services.Rents;

namespace HouseRentingSystem.Tests.UnitTests
{
    [TestFixture]
    public class RentServiceTests : UnitTestsBase
    {
        private IRentService rentService;

        [OneTimeSetUp]
        public void SetUp()
            => this.rentService = new RentService(this.data, this.mapper);

        [Test]
        public void All_ShouldReturnCorrectData()
        {
            // Arrange

            // Act: invoke the service method
            var result = this.rentService.All();

            // Assert the result is not null
            Assert.That(result, Is.Not.Null);

            // Assert the returned rents' count is correct
            var rentedHousesInDb = this.data.Houses
                .Where(h => h.RenterId != null);
            Assert.That(rentedHousesInDb.Count(), Is.EqualTo(result.ToList().Count()));


            // Assert a returned rent's data is correct
            var resultHouse = result.ToList()
                .Find(h => h.HouseTitle == this.RentedHouse.Title);
            Assert.That(resultHouse,Is.Not.Null);
            Assert.That(this.Renter.Email, Is.EqualTo(resultHouse.RenterEmail));
            Assert.That(this.Renter.FirstName + " " + this.Renter.LastName, Is.EqualTo(resultHouse.RenterFullName));
            Assert.That(this.Agent.User.Email, Is.EqualTo(resultHouse.AgentEmail));
            Assert.That(this.Agent.User.FirstName + " " + this.Agent.User.LastName, Is.EqualTo(resultHouse.AgentFullName));

        }
    }
}
