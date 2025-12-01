using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Valdiators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
        }
    }
}
