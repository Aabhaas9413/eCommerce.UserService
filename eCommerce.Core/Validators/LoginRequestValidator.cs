using eCommerce.Core.Entities.DTOs;
using FluentValidation;

namespace eCommerce.Core.Validators
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() {
        
            RuleFor(temp => temp.Password)
                .NotEmpty().WithMessage("Password is required.");
            RuleFor(temp => temp.Email)
                .NotEmpty().WithMessage("Email cannot be empty")
                .EmailAddress().WithMessage("Should be an Email.");
        }

    }
}
