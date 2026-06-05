using FluentValidation;
using MoveisRental.Core.ValidationMessages;
using MoveisRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Directors.Commands.UpdateDirector
{
    public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
    {
        public UpdateDirectorCommandValidator() 
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty).WithMessage(ValidationMessages.ERROR_MESSAGE);

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ValidationMessages.ERROR_MESSAGE)
                .MinimumLength(Director.Min_Length).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE);

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ValidationMessages.ERROR_MESSAGE)
                .MinimumLength(Director.Min_Length).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE);
        }
    }
}
