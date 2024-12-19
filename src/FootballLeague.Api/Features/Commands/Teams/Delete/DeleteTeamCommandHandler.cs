using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Commands.Teams.Delete
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly AppDbContext _context;

        public DeleteTeamCommandHandler(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _context
                .Teams
                .Include(x => x.Standings)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {request.Id} was not found.");
            }

            _context.Teams.Remove(team);


            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
