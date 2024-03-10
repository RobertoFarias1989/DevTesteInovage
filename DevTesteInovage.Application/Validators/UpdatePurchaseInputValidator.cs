using DevTesteInovage.Application.Models;
using DevTesteInovage.Core.Enums;
using FluentValidation;

namespace DevTesteInovage.Application.Validators
{
    public class UpdatePurchaseInputValidator : AbstractValidator<UpdatePurchaseInputModel>
    {
        public UpdatePurchaseInputValidator()
        {
            RuleFor(p => p.Status)
                .IsEnumName(typeof(PurchaseStatusEnum), caseSensitive: true)
                .WithMessage("Must be a valid status.");
        }
    }
}
