using DevTesteInovage.Application.Models;
using FluentValidation;

namespace DevTesteInovage.Application.Validators
{
    public class AddProductInputValidator : AbstractValidator<AddProductInputModel>
    {
        public AddProductInputValidator()
        {
            RuleFor(p => p.Title)
              .MaximumLength(50)
              .WithMessage("Maximum length of Title is 50 characters.");

            RuleFor(p => p.Description)
             .MaximumLength(254)
             .WithMessage("Maximum length of Description is 254 characters.");
        }
    }
}
