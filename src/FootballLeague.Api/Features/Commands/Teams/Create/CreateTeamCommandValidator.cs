using FluentValidation;
using FootballLeague.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using static FootballLeague.Api.AppConstants;

namespace FootballLeague.Api.Features.Commands.Teams.Create
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator(AppDbContext _context)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                    .WithMessage("Team name is required")
                .MaximumLength(TeamNameMaxLenght)
                    .WithMessage($"Team name must not exceed {TeamNameMaxLenght} characters")
                .MinimumLength(TeamNameMinLenght)
                    .WithMessage($"Team name must be longer then {TeamNameMinLenght-1} characters")
                .MustAsync(async (name, cancellationToken) => !await _context.Teams.AnyAsync(x => x.Name == name, cancellationToken))
                    .WithMessage("A team with the same name already exists.");
        }
    }
}
