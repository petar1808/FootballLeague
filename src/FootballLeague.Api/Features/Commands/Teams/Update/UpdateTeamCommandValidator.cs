using FluentValidation;
using FootballLeague.Api.Persistence;

namespace FootballLeague.Api.Features.Commands.Teams.Update
{
    public class UpdateTeamCommandValidator : AbstractValidator<UpdateTeamCommand>
    {
        public UpdateTeamCommandValidator(AppDbContext context)
        {
            Include(new TeamCommonCommandValidator(context));
        }
    }
}
