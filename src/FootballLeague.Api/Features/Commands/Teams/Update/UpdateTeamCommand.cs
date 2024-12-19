using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Teams.Update
{
    public class UpdateTeamCommand : TeamCommonCommand, IRequest<TeamResponse>
    {
        public int Id { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
