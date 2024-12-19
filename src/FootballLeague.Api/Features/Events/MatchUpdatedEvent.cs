using MediatR;

namespace FootballLeague.Api.Features.Events
{
    public class MatchUpdatedEvent : INotification
    {
        public MatchUpdatedEvent(int teamId, int oldGoalsScored, int oldGoalsConceded, int newGoalsScored, int newGoalsConceded)
        {
            OldGoalsScored = oldGoalsScored;
            OldGoalsConceded = oldGoalsConceded;
            NewGoalsScored = newGoalsScored;
            NewGoalsConceded = newGoalsConceded;
            TeamId = teamId;
        }

        public int TeamId { get; }

        public int OldGoalsScored { get; }

        public int OldGoalsConceded { get; }

        public int NewGoalsScored { get; }

        public int NewGoalsConceded { get; }
    }
}
