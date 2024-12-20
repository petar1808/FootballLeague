using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Queries.Matches.List
{
    public class ListMatchQueryHandler : IRequestHandler<ListMatchQuery, IEnumerable<MatchDetailsResponse>>
    {
        private readonly AppDbContext _context;

        public ListMatchQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchDetailsResponse>> Handle(ListMatchQuery request, CancellationToken cancellationToken)
        {
            return await _context.Matches
                .Include(x => x.AwayTeam)
                .Include(x => x.HomeTeam)
                .Select(x => MatchDetailsResponse.MatchDetailsResponseFromMatch(x))
                .ToListAsync(cancellationToken);
        }
    }
}
