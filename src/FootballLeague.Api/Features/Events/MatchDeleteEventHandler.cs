using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Events
{
    public class MatchDeleteEventHandler : INotificationHandler<MatchDeleteEvent>
    {
        private readonly AppDbContext _context;

        public MatchDeleteEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(MatchDeleteEvent notification, CancellationToken cancellationToken)
        {
            var standings = await _context.Standings.FirstOrDefaultAsync(x => x.TeamId == notification.TeamId, cancellationToken);

            if (standings == null)
            {
                throw new ArgumentNullException($"Standings for TeamId {notification.TeamId} was not found.");
            }

            standings.RemoveRecord(
                notification.GoalsScored, 
                notification.GoalsConceded);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
