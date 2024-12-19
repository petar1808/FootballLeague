using FootballLeague.Api.Features.Commands.Teams.Create;
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
    }
}
