using FluentValidation;
using YMYPHibritGroup.API.Model.Services.DTO;

namespace YMYPHibritGroup.API.Model.Services.Validators
{
    public class AddProductRequestValidator :AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            //!!! Bu kısma sadece static validatorları yazmalıyız.Yani veri tabanı, API gibi durumlara gitme zorunluluğu olmayan kodları yazmalıyız.


            //fluent API syntax approach
            RuleFor(x => x.Name).Length(5, 20).WithMessage("Name must be between 5 and 20 characters");
            RuleFor(x => x.Name).NotNull().WithMessage("Name is required");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Stock).GreaterThan(0).WithMessage("Stock must be greater than 0");

            //RuleFor(x => x.Name).Must(x => x.StartsWith("A")).WithMessage("Ürün ismi A harfi ile başlamalıdır.");

            RuleFor(x => x.Name).Must(MustBeStartWithAChar).WithMessage("Ürün ismi A harfi ile başlamalıdır.");
        }

        public bool MustBeStartWithAChar(string name)
        {
            return name.StartsWith("A");
        }
    }
}
