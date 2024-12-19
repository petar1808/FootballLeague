using FootballLeague.Api.Persistence;
using MediatR;
using FootballLeague.Api.Entities;
using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Services;

namespace FootballLeague.Api.Features.Commands.Teams.Create
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, TeamResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        private readonly ITransactionManager _transactionManager;

        public CreateTeamCommandHandler(AppDbContext context, IMediator mediator, ITransactionManager transactionManager)
        {
            _context = context;
            _mediator = mediator;
            _transactionManager = transactionManager;
        }

        public async Task<TeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _transactionManager.BeginTransactionAsync(cancellationToken);

            try
            {
                var team = new Team(request.Name);

                _context.Teams.Add(team);
                await _context.SaveChangesAsync(cancellationToken);

                var createTeamEvent = new TeamCreatedEvent(team.Id);
                await _mediator.Publish(createTeamEvent, cancellationToken);

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
