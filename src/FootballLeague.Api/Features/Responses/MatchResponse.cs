
using FootballLeague.Api.Entities;

namespace FootballLeague.Api.Features.Responses
{
    public class MatchResponse
    {
        public int Id { get; set; }
        public DateTime MatchDate { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public static MatchResponse MatchResponseFromMatch(Match match)
        {
            return new MatchResponse
            {
                Id = match.Id,
                MatchDate = match.MatchDate,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId,
                HomeTeamScore = match.HomeTeamScore,
                AwayTeamScore = match.AwayTeamScore
            };
        }
    }
}
