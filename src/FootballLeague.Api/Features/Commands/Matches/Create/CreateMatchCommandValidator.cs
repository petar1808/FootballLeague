using FluentValidation;

namespace FootballLeague.Api.Features.Commands.Matches.Create
{
    public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
    {
        public CreateMatchCommandValidator()
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
