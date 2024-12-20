using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Queries.Matches.Get
{
    public class GetMatchQueryHandler : IRequestHandler<GetMatchQuery, MatchDetailsResponse>
    {
        private readonly AppDbContext _context;

        public GetMatchQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MatchDetailsResponse> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            var match = await _context.Matches
                .Include(x => x.HomeTeam)
                .Include(x => x.AwayTeam)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (match == null)
            {
                throw new KeyNotFoundException($"Match with ID {request.Id} was not found.");
            }

            return MatchDetailsResponse.MatchDetailsResponseFromMatch(match);
        }
    }
}
