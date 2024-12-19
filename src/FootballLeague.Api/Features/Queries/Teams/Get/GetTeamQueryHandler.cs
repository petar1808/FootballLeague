using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Queries.Teams.Get
{
    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, TeamResponse>
    {
        private readonly AppDbContext _context;

        public GetTeamQueryHandler(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public async Task<TeamResponse> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var team = await _context
                .Teams
                .FindAsync(request.Id, cancellationToken);

            if (team == null)
            {
                throw new KeyNotFoundException($"Team with ID {request.Id} was not found.");
            }

            return new TeamResponse(team.Id, team.Name);
        }
    }
}
