﻿using FootballLeague.Api.Features.Responses;
using MediatR;

namespace FootballLeague.Api.Features.Queries.Teams.List
{
    public class TeamListQuery : IRequest<IEnumerable<TeamResponse>>
    {
    }
}
