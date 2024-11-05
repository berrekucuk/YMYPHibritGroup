using FluentValidation;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Model.Services.Validators
{
    public class UpdateProductPriceRequestValidator: AbstractValidator<UpdateProductPriceRequest>
    {
        public UpdateProductPriceRequestValidator()
        {
            RuleFor( x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0");
            RuleFor( x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
}
