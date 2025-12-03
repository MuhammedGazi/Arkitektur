using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Valdiators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address Boş Bırakılamaz");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("PhoneNumber Boş Bırakılamaz");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email Boş Bırakılamaz");

            RuleFor(x => x.MapUrl)
                .NotEmpty()
                .WithMessage("MapUrl Boş Bırakılamaz");
        }
    }
}
