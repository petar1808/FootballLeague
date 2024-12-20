using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Tests.Events
{
    public class TeamCreatedEventHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldAddStanding_WhenTeamCreatedEventIsHandled()
        {
            // Arrange
            var options = TestDatabaseHelper.CreateInMemoryDatabaseOptions("TestDatabase_TeamCreatedEvent");
            var teamId = new Faker().Random.Int(1, 1000);
            var notification = new TeamCreatedEvent(teamId);

            await using var context = new AppDbContext(options);
            var handler = new TeamCreatedEventHandler(context);

            // Act
            await handler.Handle(notification, CancellationToken.None);

            // Assert
            var standing = await context.Standings.FirstOrDefaultAsync(s => s.TeamId == teamId);
            standing.Should().NotBeNull();
            standing.TeamId.Should().Be(teamId);
        }
    }
}
