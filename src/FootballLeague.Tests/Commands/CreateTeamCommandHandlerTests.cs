using FootballLeague.Api.Features.Commands.Teams.Create;
using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Persistence;
using FootballLeague.Api.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Tests.Commands
{
    public class CreateTeamCommandHandlerTests
    {
        private readonly Faker _faker = new();
        private readonly IMediator _mediator;
        private readonly ITransactionManager _transactionManager;

        public CreateTeamCommandHandlerTests()
        {
            _mediator = Substitute.For<IMediator>();
            _transactionManager = Substitute.For<ITransactionManager>();
        }

        [Fact]
        public async Task Handle_ShouldCreateTeam_AndCommitTransaction()
        {
            // Arrange
            var teamName = _faker.Company.CompanyName();
            var options = TestDatabaseHelper.CreateInMemoryDatabaseOptions("TestDatabase_CreateTeam");
            var command = new CreateTeamCommand { Name = teamName };

            await using var context = new AppDbContext(options);
            var handler = new CreateTeamCommandHandler(context, _mediator, _transactionManager);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(teamName);
            result.Id.Should().BeGreaterThan(0);

            var createdTeam = await context.Teams.FindAsync(result.Id);
            createdTeam.Should().NotBeNull();
            createdTeam!.Name.Should().Be(teamName);

            await _mediator.Received(1).Publish(Arg.Any<TeamCreatedEvent>(), Arg.Any<CancellationToken>());
        }
    }

}
