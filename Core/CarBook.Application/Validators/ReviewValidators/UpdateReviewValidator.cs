using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Bu Alan Zorunludur");
            RuleFor(x => x.CustomerName).MinimumLength(6).WithMessage("En Az 6 Karakterlik Veri Girişi Yapınız");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Bu Alan Zorunludur");
            RuleFor(x => x.CustomerComment).NotEmpty().WithMessage("Bu Alan Zorunludur");
            RuleFor(x => x.CustomerComment).MinimumLength(50).WithMessage("Lütfen Yorum Kısmına En Az 50 Karakterlik Veri Girişi Yapınız");
            RuleFor(x => x.CustomerComment).MaximumLength(500).WithMessage("Lütfen Yorum Kısmına En Fazla 500 Karakterlik Veri Girişi Yapınız");
        }
    }
}
