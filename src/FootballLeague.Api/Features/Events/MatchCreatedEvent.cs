using MediatR;

namespace FootballLeague.Api.Features.Events
{
    public class MatchCreatedEvent : INotification
    {
        public MatchCreatedEvent(int teamId, int goalsScored, int goalsConceded)
        {
            TeamId = teamId;
            GoalsScored = goalsScored;
            GoalsConceded = goalsConceded;

        }
        public int TeamId { get; }

        public int GoalsScored { get; }

        public int GoalsConceded { get; }
    }
}
