using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Events
{
    public class MatchUpdatedEventHandler : INotificationHandler<MatchUpdatedEvent>
    {
        private readonly AppDbContext _context;

        public MatchUpdatedEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(MatchUpdatedEvent notification, CancellationToken cancellationToken)
        {
            var standings = await _context.Standings.FirstOrDefaultAsync(x => x.TeamId == notification.TeamId);

            if (standings == null)
            {
                throw new ArgumentNullException($"Standings for TeamId {notification.TeamId} was not found.");
            }

            standings.UpdateRecord(
                oldGoalsScored: notification.OldGoalsScored,
                oldGoalsConceded: notification.OldGoalsConceded,
                newGoalsScored: notification.NewGoalsScored,
                newGoalsConceded: notification.NewGoalsConceded);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
