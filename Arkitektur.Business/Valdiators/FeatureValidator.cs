using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Valdiators
{
    public class FeatureValidator : AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter uzunluğunda olmalıdır.")
                .MaximumLength(150).WithMessage("Başlık en fazla 150 karakter uzunluğunda olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter uzunluğunda olabilir.");

            RuleFor(x => x.BackgroundImage)
                .NotEmpty().WithMessage("BackgroundImage alanı boş bırakılamaz.")
                .MaximumLength(2048).WithMessage("Arka Plan Resmi URL'si en fazla 2048 karakter olabilir.");

            RuleFor(x => x.Icon)
                .NotEmpty().WithMessage("Icon alanı boş bırakılamaz.")
                .MaximumLength(2048).WithMessage("Simge alanı en fazla 2048 karakter olabilir.");

        }
    }
}

