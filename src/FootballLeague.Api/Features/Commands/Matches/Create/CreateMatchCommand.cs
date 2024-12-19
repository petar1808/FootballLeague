using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Matches.Create
{
    public class CreateMatchCommand : IRequest<MatchResponse>
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
    }
}
