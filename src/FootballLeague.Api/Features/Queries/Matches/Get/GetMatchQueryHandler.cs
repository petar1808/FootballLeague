using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;

namespace FootballLeague.Api.Features.Queries.Matches.Get
{
    public class GetMatchQueryHandler : IRequestHandler<GetMatchQuery, MatchResponse>
    {
        private readonly AppDbContext _context;

        public GetMatchQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MatchResponse> Handle(GetMatchQuery request, CancellationToken cancellationToken)
        {
            var match = await _context.Matches.FindAsync(request.Id, cancellationToken);

            if (match == null)
            {
                throw new KeyNotFoundException($"Match with ID {request.Id} was not found.");
            }

            return MatchResponse.FromMatch(match);
        }
    }
}
