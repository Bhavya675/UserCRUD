using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MinimalAPI.Models.DTO.Request;

namespace MinimalAPI.Common.Validators
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            RuleFor(user => user.FirstName).NotEmpty().WithMessage("First name is empty");
            RuleFor(user => user.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(user => user.Username).NotEmpty().WithMessage("Username is required");
            RuleFor(user => user.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(user => user.Password).NotEmpty().WithMessage("Password is required").MinimumLength(8).WithMessage("Password must be at least 8 characters long");
            RuleFor(user => user.Address).NotEmpty().WithMessage("Address is required");
            RuleFor(user => user.PhoneNumber).NotEmpty().WithMessage("PhoneNumber is required");
            RuleFor(user => user.DateOfBirth).NotEmpty().WithMessage("Date of birth is required");
            RuleFor(user => user.IsActive).NotNull().WithMessage("Is active is required");
            RuleFor(user => user.Role).NotEmpty().WithMessage("Role is required");
        }
    }

    public class LoginValidator : AbstractValidator<LoginRequestDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").EmailAddress().WithMessage("Invalid email format");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Email is required").MinimumLength(8).WithMessage("Password must be at least 8 characters long");
        }
    }
}