using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace CTShopSolution.ViewModels.System.Users
{
   public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required")
                .MaximumLength(250).WithMessage("FirstName can not over 250 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required")
                .MaximumLength(250).WithMessage("LastName can not over 250 characters");

            RuleFor(x => x.Dob)
                .GreaterThan(DateTime.Now.AddYears(-100)).WithMessage("Birthday cannot grater than 100 year old");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(250).WithMessage("LastName can not over 250 characters")
                .EmailAddress().WithMessage("Email format not match");


            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username  is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password name is required")
                .MinimumLength(6).WithMessage("Password is at least 6 characters");

            RuleFor(x => x).Custom((request, context) => {
                if (request.Password != request.ConfirmPassword)
                {
                    context.AddFailure("Confirm Password is not match");
                }
            });
        }
    }
}
