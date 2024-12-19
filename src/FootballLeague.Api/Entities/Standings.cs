using FootballLeague.Api.Features.Events;

namespace FootballLeague.Api.Entities
{
    public class Standings
    {
        public Standings(int teamId)
        {
            TeamId = teamId;
        }
        public int Id { get; }
        public int TeamId { get; }
        public int MatchesPlayed { get; private set; }
        public int Wins { get; private set; }
        public int Draws { get; private set; }
        public int Losses { get; private set; }
        public int GoalsScored { get; private set; }
        public int GoalsConceded { get; private set; }
        public int Points { get; private set; }

        public Team Team { get; }

        public void AddRecord(int goalsScored, int goalsConceded)
        {
            ProcessMatchRecord(goalsScored, goalsConceded);
        }

        public void RemoveRecord(int goalsScored, int goalsConceded)
        {
            ProcessMatchRecord(goalsScored, goalsConceded, true);
        }

        public void UpdateRecord(int oldGoalsScored, int oldGoalsConceded, int newGoalsScored, int newGoalsConceded)
        {
            // Revert the old record
            ProcessMatchRecord(oldGoalsScored, oldGoalsConceded, isReverting: true);
            // Add the new record
            ProcessMatchRecord(newGoalsScored, newGoalsConceded);
        }

        private void ProcessMatchRecord(int goalsScored, int goalsConceded, bool isReverting = false)
        {
            int modifier = isReverting ? -1 : 1;

            MatchesPlayed += modifier;
            GoalsScored += goalsScored * modifier;
            GoalsConceded += goalsConceded * modifier;

            if (goalsScored > goalsConceded)
            {
                Wins += modifier;
                Points += 3 * modifier;
            }
            else if (goalsScored < goalsConceded)
            {
                Losses += modifier;
            }
            else
            {
                Draws += modifier;
                Points += 1 * modifier;
            }
        }
    }
}
