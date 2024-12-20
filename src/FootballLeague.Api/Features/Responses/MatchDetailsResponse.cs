using FootballLeague.Api.Entities;

namespace FootballLeague.Api.Features.Responses
{
    public class MatchDetailsResponse : MatchResponse
    {
        public string HomeTeamName { get; set; }

        public string AwayTeamName { get; set; }

        public static MatchDetailsResponse MatchDetailsResponseFromMatch(Match match)
        {
            return new MatchDetailsResponse
            {
                Id = match.Id,
                MatchDate = match.MatchDate,
                HomeTeamId = match.HomeTeamId,
                AwayTeamId = match.AwayTeamId,
                HomeTeamScore = match.HomeTeamScore,
                AwayTeamScore = match.AwayTeamScore,
                AwayTeamName = match.AwayTeam.Name,
                HomeTeamName = match.HomeTeam.Name
            };
        }
    }
}
