using FootballLeague.Api.Entities;
using FootballLeague.Api.Persistence;
using MediatR;

namespace FootballLeague.Api.Features.Events
{
    public class TeamCreatedEventHandler : INotificationHandler<TeamCreatedEvent>
    {
        private readonly AppDbContext _context;

        public TeamCreatedEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(TeamCreatedEvent notification, CancellationToken cancellationToken)
        {
            var standing = new Standings(notification.TeamId);

            _context.Standings.Add(standing);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
