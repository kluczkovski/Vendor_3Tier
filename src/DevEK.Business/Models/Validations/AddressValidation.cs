using System;
using FluentValidation;

namespace DevEK.Business.Models.Validations
{
    public class AddressValidation : AbstractValidator<Address>
    {
        public AddressValidation()
        {
            RuleFor(a => a.Street)
                .NotEmpty().WithMessage("The field {PropertyName} must be inform.")
                .Length(2, 70).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} caracters.");

            RuleFor(a => a.Region)
                .NotEmpty().WithMessage("The field {PropertyName} must be inform.")
                .Length(2, 100).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} caracters.");

            RuleFor(a => a.PostCode)
                .NotEmpty().WithMessage("The field {PropertyName} must be inform.")
                .Length(8).WithMessage("The field {PropertyName} must have {MaxLength}.");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("The field {PropertyName} must be inform.")
                .Length(2, 50).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} caracters.");

            RuleFor(a => a.Number)
                .NotEmpty().WithMessage("The field {PropertyName} must be inform.")
                .Length(2, 10).WithMessage("The field {PropertyName} must be between {MinLength} and {MaxLength} caracters.");

        }
    }
}
