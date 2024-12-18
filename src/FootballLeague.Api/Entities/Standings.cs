namespace FootballLeague.Api.Entities
{
    public class Standings
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }

        public Team Team { get; set; }
    }
}
