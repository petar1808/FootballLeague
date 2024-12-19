using MediatR;

namespace FootballLeague.Api.Features.Events
{
    public class TeamCreatedEvent : INotification
    {
        public TeamCreatedEvent(int teamId)
        {
            TeamId = teamId;
        }

        public int TeamId { get; }
    }
}
