using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Queries.Teams.Get
{
    public class TeamGetQuery : IRequest<TeamResponse>
    {
        public int Id { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
