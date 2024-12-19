using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Commands.Teams.Delete
{
    public class TeamDeleteCommandHandler : IRequestHandler<TeamDeleteCommand>
    {
        private readonly AppDbContext _appDbContext;

        public TeamDeleteCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task Handle(TeamDeleteCommand request, CancellationToken cancellationToken)
        {
            var team = await _appDbContext
                .Teams
                .Include(x => x.Standings)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {request.Id} was not found.");
            }

            _appDbContext.Teams.Remove(team);


            await _appDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
