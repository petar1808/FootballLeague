using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Queries.Standings
{
    public class ListStandingsQueryHandler : IRequestHandler<ListStandingsQuery, IEnumerable<StandingsResponse>>
    {
        private readonly AppDbContext _context;

        public ListStandingsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StandingsResponse>> Handle(ListStandingsQuery request, CancellationToken cancellationToken)
        {
            var standings = await _context.Standings
                .Include(x => x.Team)
                .OrderByDescending(x => x.Points)
                    .ThenByDescending(x => x.Wins)
                    .ThenByDescending(x => x.GoalsScored)
                .ToListAsync();

            return standings
                .Select((record, index) => new StandingsResponse
                {
                    RankingId = index+1,
                    TeamId = record.TeamId,
                    TeamName = record.Team.Name,
                    MatchesPlayed = record.MatchesPlayed,
                    Wins = record.Wins,
                    Draws = record.Draws,
                    Losses = record.Losses,
                    GoalsScored = record.GoalsScored,
                    GoalsConceded = record.GoalsConceded,
                    Points = record.Points
                });
        }
    }
}
