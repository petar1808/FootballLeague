using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Queries.Teams.Get
{
    public class GetTeamQuery : IRequest<TeamResponse>
    {
        public GetTeamQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
