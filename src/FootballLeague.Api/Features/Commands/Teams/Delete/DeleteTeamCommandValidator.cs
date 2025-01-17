﻿using FluentValidation;
using FootballLeague.Api.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Api.Features.Commands.Teams.Delete
{
    public class DeleteTeamCommandValidator : AbstractValidator<DeleteTeamCommand>
    {
        public DeleteTeamCommandValidator(AppDbContext appContext)
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, cancellationToken) =>
                {
                    return !await appContext.Matches.AnyAsync(x => x.HomeTeamId == id || x.AwayTeamId == id);
                })
                .WithMessage("There are already matches created for this team, you must delete its matches first!");
        }
    }
}
