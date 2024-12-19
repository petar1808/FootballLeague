using MediatR;

namespace FootballLeague.Api.Features.Commands.Teams.Delete
{
    public class TeamDeleteCommand : IRequest
    {
        public int Id { get; private set; }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
