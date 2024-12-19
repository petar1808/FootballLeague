﻿using FootballLeague.Api.Features.Responses;
using FootballLeague.Api.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Queries.Teams.List
{
    public class ListTeamQueryHandler : IRequestHandler<ListTeamQuery, IEnumerable<TeamResponse>>
    {
        private readonly AppDbContext _appDbContext;

        public ListTeamQueryHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<TeamResponse>> Handle(ListTeamQuery request, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .Teams
                .Select(x => new TeamResponse(x.Id, x.Name))
                .ToListAsync(cancellationToken);
        }
    }
}