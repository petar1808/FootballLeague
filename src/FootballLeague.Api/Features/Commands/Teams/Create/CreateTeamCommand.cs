using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Teams.Create
{
    public class CreateTeamCommand : IRequest<TeamResponse>
    {
        public string Name { get; set; }
    }
}
