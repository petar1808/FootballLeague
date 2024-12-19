using FootballLeague.Api.Features.Commands.Teams.Create;
using FootballLeague.Api.Features.Commands.Teams.Delete;
using FootballLeague.Api.Features.Commands.Teams.Update;
using FootballLeague.Api.Features.Queries.Teams.Get;
using FootballLeague.Api.Features.Queries.Teams.List;
using FootballLeague.Api.Features.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.Api.Controllers
{
    [Route("api/team")]
    public class TeamController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeamController(IMediator mediator) 
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<ActionResult<TeamResponse>> CreateTeam([FromBody] CreateTeamCommand request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TeamResponse>> UpdateTeam(int id, [FromBody] UpdateTeamCommand request)
        {
            request.SetId(id);
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTeam(int id)
        {
            await _mediator.Send(new DeleteTeamCommand(id));
            return Ok();
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<TeamResponse>>> ListTeams()
        {
            return Ok(await _mediator.Send(new ListTeamQuery()));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TeamResponse>> GetTeamById(int id)
        {
            return await _mediator.Send(new GetTeamQuery(id));
        }
    }
}
