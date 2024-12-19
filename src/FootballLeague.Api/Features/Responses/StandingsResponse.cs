using FootballLeague.Api.Entities;

namespace FootballLeague.Api.Features.Responses
{
    public class StandingsResponse
    {
        //public StandingsResponse(
        //    int rankingId, 
        //    int teamId, 
        //    int teamName, 
        //    int matchesPlayed, 
        //    int wins, 
        //    int draws, 
        //    int losses, 
        //    int goalsScored, 
        //    int goalsConceded)
        //{
        //    RankingId = rankingId;
        //    TeamId = teamId;
        //    TeamName = teamName;
        //    MatchesPlayed = matchesPlayed;
        //    Wins = wins;
        //    Draws = draws;
        //    Losses = losses;
        //    GoalsScored = goalsScored;
        //    GoalsConceded = goalsConceded;
        //}

        public int RankingId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsConceded { get; set; }

        public int GoalDifference => GoalsScored - GoalsConceded;

        public int Points { get; set; }


        //public static StandingsResponse FromStandings(Standings standings)
        //{

        //}
    }
}
