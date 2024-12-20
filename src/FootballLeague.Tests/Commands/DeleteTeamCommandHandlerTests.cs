using FootballLeague.Api.Features.Commands.Teams.Delete;
using FootballLeague.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Tests.Commands
{
    public class DeleteTeamCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldDeleteTeam_WhenTeamExists()
        {
            // Arrange
            var context = await TestDatabaseHelper.InitializeDatabaseWithTeamAsync("Team1");
            var team = await context.Teams.FirstOrDefaultAsync();

            var command = new DeleteTeamCommand(team.Id);
            var handler = new DeleteTeamCommandHandler(context);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            var deletedTeam = await context.Teams.FirstOrDefaultAsync(x => x.Id == team.Id);
            deletedTeam.Should().BeNull();
        }

        [Fact]
        public async Task Handle_ShouldThrowKeyNotFoundException_WhenTeamDoesNotExist()
        {
            // Arrange
            var options = TestDatabaseHelper.CreateInMemoryDatabaseOptions("TestDatabase_TeamNotFound");
            await using var context = new AppDbContext(options);

            var command = new DeleteTeamCommand(999); // Non-existing ID
            var handler = new DeleteTeamCommandHandler(context);

            // Act
            Func<Task> act = async () => await handler.Handle(command, CancellationToken.None);

            // Assert
            await act.Should().ThrowAsync<KeyNotFoundException>()
                .WithMessage("Team with ID 999 was not found.");
        }

        [Fact]
        public async Task Handle_ShouldDeleteTeamAndStandings_WhenTeamExistsWithStandings()
        {
            // Arrange
            var context = await TestDatabaseHelper.InitializeDatabaseWithTeamAndStandingsAsync("Team with Standings");
            var team = await context.Teams.FirstOrDefaultAsync();

            var command = new DeleteTeamCommand(team.Id);
            var handler = new DeleteTeamCommandHandler(context);

            // Act
            await handler.Handle(command, CancellationToken.None);

            // Assert
            var deletedTeam = await context.Teams.FirstOrDefaultAsync(x => x.Id == team.Id);
            deletedTeam.Should().BeNull();

            var deletedStandings = await context.Standings.FirstOrDefaultAsync(x => x.TeamId == team.Id);
            deletedStandings.Should().BeNull();
        }
    }
}
