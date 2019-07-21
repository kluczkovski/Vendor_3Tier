using System;
using FluentValidation;

namespace DevEK.Business.Models.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("The field {PropertyName} must be inform.")
                .Length(2, 70).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} caracters.");

            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("The field {PropertyName} must be inform.")
                .Length(2, 500).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} caracters.");

            RuleFor(p => p.Value)
                .GreaterThan(0).WithMessage("The field {PropertyName} must be grater than {ComparisonValue}");
        }
    }
}
