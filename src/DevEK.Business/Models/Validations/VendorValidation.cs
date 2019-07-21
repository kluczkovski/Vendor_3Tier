using DevEK.Business.Models.Enums;
using FluentValidation;
using DevEK.Business.Models.Validations.Documents;

namespace DevEK.Business.Models.Validations
{
    public class VendorValidation : AbstractValidator<Vendor>
    {
        public VendorValidation()
        {
            RuleFor(n => n.Name)
              .NotEmpty()
              .Length(2, 100).WithMessage("The field {PropertyName} shoud be between {MinLength} and {MaxLength} caracters.");

            When(d => d.VendorType == VendorType.Física,
                () => {
                    RuleFor(d => d.IdentifiyDocument.Length).Equal(CpfValidacao.TamanhoCpf)
                    .WithMessage("The field document must have {ComparisonValue} caracters and was informed {PropertyValue}.");
                    RuleFor(d => CpfValidacao.Validar(d.IdentifiyDocument)).Equal(true)
                    .WithMessage("The Document informed is invalid.");
                }); 

            When(d => d.VendorType == VendorType.Jurídica,
                () => {
                    RuleFor(d => d.IdentifiyDocument.Length).Equal(CnpjValidacao.TamanhoCnpj)
                    .WithMessage("The field document must have {ComparisonValue} caracters and was informed {PropertyValue}.");
                    RuleFor(d => CnpjValidacao.Validar(d.IdentifiyDocument)).Equal(true)
                    .WithMessage("The Document informed is invalid.");
                });
        }
    }
}
