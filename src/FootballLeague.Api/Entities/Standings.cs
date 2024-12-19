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
        //public int GoalDifference { get; private set; }
        public int Points { get; private set; }

        public Team Team { get; }
    }
}
