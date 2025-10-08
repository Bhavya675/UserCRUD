using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MinimalAPI.Models.DTO.Request;

namespace MinimalAPI.Common.Validators
{
    public class ProductValidator : AbstractValidator<ProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required").NotEmpty().WithMessage("Name cannot be empty");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price is required and it must be grater than 0");
            RuleFor(x => x.Description).MaximumLength(250).WithMessage("Description cannot be longer than 250 characters");
        }
    }
}