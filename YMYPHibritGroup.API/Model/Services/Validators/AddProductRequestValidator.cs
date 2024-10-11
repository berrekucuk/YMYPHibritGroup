﻿using FluentValidation;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Model.Services.Validators
{
    public class AddProductRequestValidator :AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            //fluent API syntax approach
            RuleFor(x => x.Name).Length(5, 20).WithMessage("Name must be between 5 and 20 characters");
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("Stock must be greater than 0");
        }
    }
}