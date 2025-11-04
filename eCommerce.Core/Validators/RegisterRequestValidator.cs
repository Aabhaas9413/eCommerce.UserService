using eCommerce.Core.Entities.DTOs;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class RegisterRequestValidator: AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(temp => temp.PersonName)
                .NotEmpty().WithMessage("PersonName is required.")
                .MinimumLength(2).WithMessage("PersonName should be at least 2 characters long.")
                .MaximumLength(100).WithMessage("PersonName should not exceed 100 characters.");
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password should be at least 6 characters long.")
                .MaximumLength(50).WithMessage("Password should not exceed 50 characters.");
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Should be an Email.");
            RuleFor(temp => temp.Gender)
                .IsInEnum().WithMessage("Gender must be a valid option.");
        }
    }
}
