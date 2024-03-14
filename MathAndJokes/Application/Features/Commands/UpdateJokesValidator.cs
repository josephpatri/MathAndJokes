using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class UpdateJokesValidator : AbstractValidator<UpdateJokes>
    {
        public UpdateJokesValidator()
        {
            RuleFor(p => p.Id).NotEmpty();

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
