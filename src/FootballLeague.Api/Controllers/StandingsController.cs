using FootballLeague.Api.Features.Queries.Standings;
using FootballLeague.Api.Features.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Api.Controllers
{
    [ApiController]
    [Route("api/standings")]
    public class StandingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StandingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StandingsResponse>>> List()
        {
            return Ok(await _mediator.Send(new ListStandingsQuery()));
        }
    }
}
