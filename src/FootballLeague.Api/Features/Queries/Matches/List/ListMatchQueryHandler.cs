using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Queries.Matches.List
{
    public class ListMatchQueryHandler : IRequestHandler<ListMatchQuery, IEnumerable<MatchResponse>>
    {
        private readonly AppDbContext _context;

        public ListMatchQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchResponse>> Handle(ListMatchQuery request, CancellationToken cancellationToken)
        {
            return await _context.Matches
                .Select(x => MatchResponse.FromMatch(x))
                .ToListAsync(cancellationToken);
        }
    }
}
