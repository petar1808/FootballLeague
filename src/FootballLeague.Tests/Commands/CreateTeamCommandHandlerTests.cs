using FootballLeague.Api.Features.Commands.Teams.Create;
using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Tests.Commands
{
    public class CreateTeamCommandHandlerTests
    {
        private readonly Faker _faker = new Faker();
        private readonly IMediator _mediator;
        private readonly ITransactionManager _transactionManager;

        public CreateTeamCommandHandlerTests()
        {
            _mediator = Substitute.For<IMediator>();
            _transactionManager = Substitute.For<ITransactionManager>();
        }

        private CreateTeamCommand CreateValidCommand()
        {
            var teamName = _faker.Company.CompanyName();
            return new CreateTeamCommand { Name = teamName };
        }

        [Fact]
        public async Task Handle_ShouldCreateTeam_AndCommitTransaction()
        {
            // Arrange
            var context = await TestDatabaseHelper.InitializeDatabaseWithTeamAsync("Team1");
            var team = await context.Teams.FirstOrDefaultAsync();

            var command = new CreateTeamCommand { Name = team.Name };
            var handler = new CreateTeamCommandHandler(context, _mediator, _transactionManager);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(team.Name);
            result.Id.Should().BeGreaterThan(0);

            var createdTeam = await context.Teams.FindAsync(result.Id);
            createdTeam.Should().NotBeNull();
            createdTeam!.Name.Should().Be(team.Name);

            await _mediator.Received(1).Publish(Arg.Any<TeamCreatedEvent>(), Arg.Any<CancellationToken>());
        }
    }
}
