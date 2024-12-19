
using FootballLeague.Api.Entities;

namespace FootballLeague.Api.Features.Responses
{
    public class MatchResponse
    {
        public MatchResponse(int id, DateTime matchDate, int homeTeamId, int awayTeamId, int homeTeamScore, int awayTeamScore)
        {
            Id = id;
            MatchDate = matchDate;
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            HomeTeamScore = homeTeamScore;
            AwayTeamScore = awayTeamScore;
        }

        public int Id { get; }
        public DateTime MatchDate { get; }
        public int HomeTeamId { get; }
        public int AwayTeamId { get; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public static MatchResponse FromMatch(Match match)
        {
            return new MatchResponse(match.Id,
                    match.MatchDate,
                    match.HomeTeamId,
                    match.AwayTeamId,
                    match.HomeTeamScore,
                    match.AwayTeamId);
        }
    }
}
