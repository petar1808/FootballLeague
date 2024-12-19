using FluentValidation;
using FootballLeague.Api.Features.Commands.Matches.Update;

namespace FootballLeague.Api.Features.Commands.Matches.Create
{
    public class UpdateMatchCommandValidator : AbstractValidator<UpdateMatchCommand>
    {
        public UpdateMatchCommandValidator()
        {
            RuleFor(x => x.HomeTeamScore)
                .GreaterThan(-1)
                    .WithMessage("HomeTeamScore should be positive number!");

            RuleFor(x => x.AwayTeamScore)
                .GreaterThan(-1)
                    .WithMessage("AwayTeamScore should be positive number!");
        }
    }
}
