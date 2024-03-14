using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    internal class CreateJokeValidator : AbstractValidator<CreateJokes>
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
        }
    }
}
