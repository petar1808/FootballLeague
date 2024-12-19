using FootballLeague.Api.Features.Commands.Matches.Create;
using FootballLeague.Api.Features.Commands.Matches.Update;
using FootballLeague.Api.Features.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Api.Controllers
{
    [ApiController]
    [Route("api/matches")]
    public class MatchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MatchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<MatchResponse>> CreateMatch([FromBody] CreateMatchCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MatchResponse>> UpdateMatch(int id, [FromBody] UpdateMatchCommand request)
        {
            request.SetId(id);
            return await _mediator.Send(request);
        }
    }
}
