using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Matches.Update
{
    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand, MatchResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;

        public UpdateMatchCommandHandler(AppDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<MatchResponse> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var match = await _context.Matches.FindAsync(request.Id, cancellationToken);

                await _mediator.Publish(new MatchUpdatedEvent(
                    teamId: match.HomeTeamId,
                    oldGoalsScored: match.HomeTeamScore,
                    oldGoalsConceded: match.AwayTeamScore,
                    newGoalsScored: request.HomeTeamScore,
                    newGoalsConceded: request.AwayTeamScore));

                await _mediator.Publish(new MatchUpdatedEvent(
                    teamId: match.AwayTeamId,
                    oldGoalsScored: match.AwayTeamScore,
                    oldGoalsConceded: match.HomeTeamScore,
                    newGoalsScored: request.AwayTeamScore,
                    newGoalsConceded: request.HomeTeamScore));

                match
                    .UpdateHomeTeamScore(request.HomeTeamScore)
                    .UpdateAwayTeamScore(request.AwayTeamScore);

                await _context.SaveChangesAsync(cancellationToken);

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
