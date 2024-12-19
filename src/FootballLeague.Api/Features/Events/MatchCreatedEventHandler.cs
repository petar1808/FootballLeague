using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Events
{
    public class MatchCreatedEventHandler : INotificationHandler<MatchCreatedEvent>
    {
        private readonly AppDbContext _context;

        public MatchCreatedEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(MatchCreatedEvent notification, CancellationToken cancellationToken)
        {
            var standings = await _context.Standings
                .FirstOrDefaultAsync(x => x.TeamId == notification.TeamId);

            if (standings == null)
            {
                throw new ArgumentNullException($"Standings for TeamId {notification.TeamId} was not found.");
            }

            standings.AddRecord(notification.GoalsScored, notification.GoalsConceded);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
