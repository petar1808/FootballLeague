using FootballLeague.Api.Entities;
using FootballLeague.Api.Features.Queries.Teams.Get;
using FootballLeague.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Tests.Queries
{
    public class GetTeamQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnTeam_WhenTeamExists()
        {
            // Arrange
            var teamName = new Faker().Company.CompanyName();
            var context = await TestDatabaseHelper.InitializeDatabaseWithTeamAsync(teamName);

            var team = await context.Teams.FirstAsync();
            var query = new GetTeamQuery(team.Id);
            var handler = new GetTeamQueryHandler(context);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(team.Id);
            result.Name.Should().Be(teamName);
        }

        [Fact]
        public async Task Handle_ShouldThrowKeyNotFoundException_WhenTeamDoesNotExist()
        {
            // Arrange
            var options = TestDatabaseHelper.CreateInMemoryDatabaseOptions("TestDatabase_TeamNotFound");
            await using var context = new AppDbContext(options);

            var query = new GetTeamQuery(999); // Non-existing team ID
            var handler = new GetTeamQueryHandler(context);

            // Act
            Func<Task> act = async () => await handler.Handle(query, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage("Team with ID 999 was not found.");
        }
    }
}
