using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Valdiators
{
    public class ChooseValidator : AbstractValidator<Choose>
    {
        public ChooseValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakterden oluşmalıdır.")
                .MaximumLength(50).WithMessage("Başlık en fazla 50 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı zorunludur.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Lütfen bir ikon bilgisi giriniz.")
                .MaximumLength(100).WithMessage("İkon bilgisi en fazla 100 karakter olabilir.");

        }
    }
}
