using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Queries.Matches.Get
{
    public class GetMatchQuery : IRequest<MatchDetailsResponse>
    {
        public GetMatchQuery(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }
}
