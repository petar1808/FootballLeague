using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Queries.Matches.List
{
    public class ListMatchQuery : IRequest<IEnumerable<MatchResponse>>
    {
    }
}
