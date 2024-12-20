using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using FootballLeague.Api.Services;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Matches.Update
{
    public class UpdateMatchCommandHandler : IRequestHandler<UpdateMatchCommand, MatchResponse>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        private readonly ITransactionManager _transactionManager;

        public UpdateMatchCommandHandler(AppDbContext context, IMediator mediator, ITransactionManager transactionManager)
        {
            _context = context;
            _mediator = mediator;
            _transactionManager = transactionManager;
        }

        public async Task<MatchResponse> Handle(UpdateMatchCommand request, CancellationToken cancellationToken)
        {
            using var transaction = await _transactionManager.BeginTransactionAsync(cancellationToken);

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

                return MatchResponse.MatchResponseFromMatch(match);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
