using MediatR;

namespace FootballLeague.Api.Features.Commands.Matches.Delete
{
    public class DeleteMatchCommnad : IRequest
    {
        public DeleteMatchCommnad(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}
