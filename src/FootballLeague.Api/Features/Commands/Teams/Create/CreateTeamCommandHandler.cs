using FootballLeague.Api.Persistence;
using MediatR;
using FootballLeague.Api.Entities;
using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Features.Events;

namespace FootballLeague.Api.Features.Commands.Teams.Create
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, TeamResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CreateTeamCommandHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<TeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var team = new Team(request.Name);

                _context.Teams.Add(team);
                await _context.SaveChangesAsync(cancellationToken);

                var @event = new TeamCreatedEvent
                {
                    TeamId = team.Id
                };

                await _mediator.Publish(@event, cancellationToken);

                await transaction.CommitAsync(cancellationToken);

                return new TeamResponse(team.Id, team.Name);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
