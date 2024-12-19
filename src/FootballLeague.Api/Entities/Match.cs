namespace FootballLeague.Api.Entities
{
    public class Match
    {
        public Match(int homeTeamId, int awayTeamId, int homeTeamScore, int awayTeamScore)
        {
            MatchDate = DateTime.UtcNow;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }

        public int Id { get; }
        public DateTime MatchDate { get; }
        public int HomeTeamId { get; }
        public int AwayTeamId { get; }
        public int HomeTeamScore { get; private set; }
        public int AwayTeamScore { get; private set; }

        public Team HomeTeam { get; }
        public Team AwayTeam { get; }

        public Match UpdateHomeTeamScore(int homeTeamScore)
        {
            HomeTeamScore = homeTeamScore;
            return this;
        }

        public Match UpdateAwayTeamScore(int awayTeamScore)
        {
            AwayTeamScore = awayTeamScore;
            return this;
        }
    }
}
