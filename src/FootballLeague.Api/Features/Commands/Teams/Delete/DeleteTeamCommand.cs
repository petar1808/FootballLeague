using MediatR;

namespace FootballLeague.Api.Features.Commands.Teams.Delete
{
    public class DeleteTeamCommand : IRequest
    {
        public DeleteTeamCommand(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
