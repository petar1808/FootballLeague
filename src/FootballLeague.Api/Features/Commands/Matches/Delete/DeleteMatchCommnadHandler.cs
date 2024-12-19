using FootballLeague.Api.Features.Events;
using FootballLeague.Api.Persistence;
using FootballLeague.Api.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Commands.Matches.Delete
{
    public class DeleteMatchCommnadHandler : IRequestHandler<DeleteMatchCommnad>
    {
        private readonly AppDbContext _context;
        private readonly IMediator _mediator;
        private readonly ITransactionManager _transactionManager;

        public DeleteMatchCommnadHandler(AppDbContext context, ITransactionManager transactionManager, IMediator mediator)
        {
            _context = context;
            _transactionManager = transactionManager;
            _mediator = mediator;
        }

        public async Task Handle(DeleteMatchCommnad request, CancellationToken cancellationToken)
        {
            using var transaction = await _transactionManager.BeginTransactionAsync(cancellationToken);

            try
            {
                var match = await _context.Matches
                    .Include(x => x.HomeTeam)
                    .Include(x => x.AwayTeam)
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if (match == null)
                {
                    throw new KeyNotFoundException($"Match with ID {request.Id} was not found.");
                }

                _context.Matches.Remove(match);
                await _context.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new MatchDeleteEvent(match.HomeTeam.Id, match.HomeTeamScore, match.AwayTeamScore));

                await _mediator.Publish(new MatchDeleteEvent(match.AwayTeam.Id, match.AwayTeamScore, match.HomeTeamScore));

                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
