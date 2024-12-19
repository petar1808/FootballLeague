using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Matches.Update
{
    public class UpdateMatchCommand : IRequest<MatchResponse>
    {
        public int Id { get; private set; }

        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }

        public void SetId(int id) 
        { 
            Id = id; 
        }
    }
}
