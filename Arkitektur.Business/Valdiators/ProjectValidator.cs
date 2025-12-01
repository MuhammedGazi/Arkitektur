using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Valdiators
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık alanı boş bırakılamaz.")
                .Length(5, 100).WithMessage("Başlık 5 ile 100 karakter arasında olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama alanı boş bırakılamaz.")
                .MinimumLength(20).WithMessage("Açıklama en az 20 karakter olmalıdır.")
                .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Lütfen bir görsel yolu belirtiniz.")
                .MaximumLength(500).WithMessage("Görsel yolu çok uzun.");

            RuleFor(x => x.Item1)
                .NotEmpty().WithMessage("1. özellik maddesi boş bırakılamaz.")
                .MaximumLength(100).WithMessage("Maddeler en fazla 100 karakter olabilir.");

            RuleFor(x => x.Item2)
                .MaximumLength(100).WithMessage("2. madde en fazla 100 karakter olabilir.");

            RuleFor(x => x.Item3)
                .MaximumLength(100).WithMessage("3. madde en fazla 100 karakter olabilir.");

            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("Lütfen geçerli bir kategori seçiniz.")
                .NotEmpty().WithMessage("Kategori seçimi zorunludur.");
        }
    }
}
