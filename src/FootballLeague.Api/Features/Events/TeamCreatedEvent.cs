using MediatR;

namespace FootballLeague.Api.Features.Events
{
    public class TeamCreatedEvent : INotification
    {
        public int TeamId { get; set; }
    }
}
