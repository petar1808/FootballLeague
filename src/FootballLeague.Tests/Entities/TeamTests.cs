using FootballLeague.Api.Entities;

namespace FootballLeague.Tests.Entities
{
    public class TeamTests
    {
        private readonly Faker _faker = new Faker();
        [Fact]
        public void Constructor_ShouldInitializeTeamWithGivenName()
        {
            // Arrange
            var teamName = _faker.Company.CompanyName();

            // Act
            var team = new Team(teamName);

            // Assert
            team.Name.Should().Be(teamName);
            team.Id.Should().Be(0);
            team.Standings.Should().BeNull();
        }

        [Fact]
        public void UpdateName_ShouldUpdateTeamName()
        {
            // Arrange
            var team = new Team(_faker.Company.CompanyName());

            // Act
            var newTeamName = "new" + _faker.Company.CompanyName();
            team.UpdateName(newTeamName);

            // Assert
            team.Name.Should().Be(newTeamName);
        }

        [Fact]
        public void UpdateName_ShouldNotChangeTeamNameIfSameNameIsProvided()
        {
            // Arrange
            var team = new Team(_faker.Company.CompanyName());

            // Act
            var originalName = team.Name;
            team.UpdateName(originalName);

            // Assert
            team.Name.Should().Be(originalName);
        }
    }
}
