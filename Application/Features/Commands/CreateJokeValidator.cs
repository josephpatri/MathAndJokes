using FluentValidation;

namespace Application.Features.Commands
{
    public class CreateJokeValidator : AbstractValidator<CreateJokes>
    {
        public CreateJokeValidator()
        {
            RuleFor(p => p.JokeName)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);

            RuleFor(p => p.JokeDescription)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(500);

            RuleFor(p => p.JokeOwner)
                .NotEmpty()
                .MinimumLength(5)
                .MaximumLength(50);
        }
    }
}
