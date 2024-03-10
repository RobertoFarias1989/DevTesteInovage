using DevTesteInovage.Application.Models;
using FluentValidation;

namespace DevTesteInovage.Application.Validators
{
    public class AddPurchaseInputValidator : AbstractValidator<AddPurchaseInputModel>
    {
        public AddPurchaseInputValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(50)
                .WithMessage("Maximum length of Description is 50 characters.");

            RuleFor(p => p.DeliveryAdress)
             .MaximumLength(254)
             .WithMessage("Maximum length of DeliveryAdress is 254 characters.");
        }
    }
}
