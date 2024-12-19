using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Queries.Standings
{
    public class ListStandingsQuery : IRequest<IEnumerable<StandingsResponse>>
    {
    }
}
