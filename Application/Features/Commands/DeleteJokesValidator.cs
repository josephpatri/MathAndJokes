using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands
{
    public class DeleteJokesValidator : AbstractValidator<DeleteJokes>
    {
        public DeleteJokesValidator()
        {
            RuleFor(p => p.Id).NotEmpty();
        }
    }
}
