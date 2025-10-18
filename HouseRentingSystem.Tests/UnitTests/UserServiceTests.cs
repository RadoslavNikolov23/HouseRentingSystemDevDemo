using HouseRentingSystem.Services.Users;

namespace HouseRentingSystem.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceTests : UnitTestsBase
    {
        private IUserService userService;

        [OneTimeSetUp]
        public void SetUp()
            => this.userService = new UserService(this.data, this.mapper);

        [Test]
        public void UserHasRents_ShouldReturnTrue_WithValidData()
        {
            // Arrange

            // Act: invoke the service method with valid renter id
            var result = this.userService.UserHasRents(this.Renter.Id);

            // Assert the retunred result is true
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void UserFullName_ShouldReturnCorrectResult()
        {
            // Arrange

            // Act: invoke the service method with valid renter id
            var result = this.userService.UserFullName(this.Renter.Id);

            // Assert the returned result is correct
            var renterFullName = this.Renter.FirstName + " " +
                this.Renter.LastName;
            Assert.That(renterFullName, Is.EqualTo(result));
        }

        [Test]
        public void All_ShouldReturnCorrectUsersAndAgents()
        {
            // Arrange

            // Act: invoke the service method
            var result = this.userService.All();

            // Assert the returned users' count is correct
            var usersCount = this.data.Users.Count();
            var resultUsers = result.ToList();
            Assert.That(usersCount, Is.EqualTo(result.Count()));

            // Assert the returned agents' count is correct
            var agentsCount = this.data.Agents.Count();
            var resultAgents = resultUsers.Where(us => us.PhoneNumber != "");
            Assert.That(agentsCount, Is.EqualTo(resultAgents.Count()));


            // Assert a returned agent data is correct
            var agentUser = resultAgents
                .FirstOrDefault(ag => ag.Email == this.Agent.User.Email);
            Assert.That(agentUser, Is.Not.Null);
            Assert.That(this.Agent.PhoneNumber, Is.EqualTo(agentUser.PhoneNumber));

        }
    }
}
