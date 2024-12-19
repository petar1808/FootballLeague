using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Queries.Teams.List
{
    public class TeamListQueryHandler : IRequestHandler<TeamListQuery, IEnumerable<TeamResponse>>
    {
        private readonly AppDbContext _appDbContext;

        public TeamListQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TeamResponse>> Handle(TeamListQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .Teams
                .Select(x => new TeamResponse(x.Id, x.Name))
                .ToListAsync(cancellationToken);
        }
    }
}
