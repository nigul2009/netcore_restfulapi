using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionSolution.Core.Application.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Name)
                   .NotEmpty().WithMessage("{PropertyName} can't be empty.")
                   .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(p => p.Surname)
               .NotEmpty().WithMessage("{PropertyName} can't be empty.")
               .MaximumLength(80).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(p => p.DateOfBirth)
               .NotEmpty().WithMessage("Date of birth can't be empty.");

            RuleFor(p => p.Telephone)
               .NotEmpty().WithMessage("{PropertyName} can't be empty.")
               .Matches(@"^\d{4}-\d{4}$").WithMessage("{PropertyName} must comply with the format 0000-0000")
               .MaximumLength(9).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(p => p.Email)
               .NotEmpty().WithMessage("{PropertyName} can't be empty.")
               .EmailAddress().WithMessage("{PropertyName} must be a valid email address")
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters");

            RuleFor(p => p.Address)
               .NotEmpty().WithMessage("{PropertyName} can't be empty.")
               .MaximumLength(120).WithMessage("{PropertyName} must not exceed {MaxLength} characters");
        }
    }
}
