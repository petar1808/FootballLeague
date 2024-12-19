using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;

namespace FootballLeague.Api.Features.Commands.Teams.Update
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand, TeamResponse>
    {
        private readonly AppDbContext _context;

        public UpdateTeamCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TeamResponse> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var team = await _context.Teams.FindAsync(request.Id, cancellationToken);

            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {request.Id} was not found.");
            }

            team.UpdateName(request.Name);

            await _context.SaveChangesAsync(cancellationToken);

            return new TeamResponse(team.Id, team.Name);
        }
    }
}
