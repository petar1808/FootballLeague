using FluentValidation;
using FootballLeague.Api.Persistence;

namespace FootballLeague.Api.Features.Commands.Teams.Create
{
    public class CreateTeamCommandValidator : AbstractValidator<CreateTeamCommand>
    {
        public CreateTeamCommandValidator(AppDbContext context)
        {
            Include(new TeamCommonCommandValidator(context));
        }
    }
}
