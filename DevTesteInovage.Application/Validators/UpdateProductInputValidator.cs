using DevTesteInovage.Application.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTesteInovage.Application.Validators
{
    public class UpdateProductInputValidator : AbstractValidator<UpdateProductInputModel>
    {
        public UpdateProductInputValidator()
        {
            RuleFor(p => p.Description)
             .MaximumLength(254)
             .WithMessage("Maximum length of Description is 254 characters.");
        }
    }
}
