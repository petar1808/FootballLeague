using FootballLeague.Api.Entities;
using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Matches.Create
{
    public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, MatchResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public CreateMatchCommandHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<MatchResponse> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var homeTeam = await _context.Teams.FindAsync(request.HomeTeamId, cancellationToken);

                if (homeTeam == null)
                {
                    throw new KeyNotFoundException($"HomeTeam with ID {request.HomeTeamId} was not found.");
                }

                var awayTeam = await _context.Teams.FindAsync(request.AwayTeamId, cancellationToken);

                if (awayTeam == null)
                {
                    throw new KeyNotFoundException($"HomeTeam with ID {request.AwayTeamId} was not found.");
                }

                var match = new Match(request.HomeTeamId,
                    request.AwayTeamId,
                    request.HomeTeamScore,
                    request.AwayTeamScore);

                await _context.Matches.AddAsync(match);

                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new MatchCreatedEvent(request.AwayTeamId, request.AwayTeamScore, request.HomeTeamScore));

                await _mediator.Publish(new MatchCreatedEvent(request.HomeTeamId, request.HomeTeamScore, request.AwayTeamScore));

                await transaction.CommitAsync(cancellationToken);

                return MatchResponse.FromMatch(match);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
