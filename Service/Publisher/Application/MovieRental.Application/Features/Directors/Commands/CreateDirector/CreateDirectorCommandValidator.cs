using FluentValidation;
using MoveisRental.Core.ValidationMessages;
using MoveisRental.Domain.Entities;


namespace MovieRental.Application.Features.Directors.Commands.CreateDirector
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(x=> x.Name)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
                .MinimumLength(Director.Min_Length).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE)
                .MaximumLength(Director.Max_Length).WithMessage(ValidationMessages.MAX_LENGTH_ERROR_MESSAGE);
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage(ValidationMessages.EMPTY_STRING_ERROR_MESSAGE)
                .MinimumLength(Director.Min_Length).WithMessage(ValidationMessages.MIN_LENGTH_ERROR_MESSAGE)
                .MaximumLength(Director.Max_Length).WithMessage(ValidationMessages.MAX_LENGTH_ERROR_MESSAGE);
        }
    }
}
