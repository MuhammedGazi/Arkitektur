using Arkitektur.Entity.Entities;
using FluentValidation;

namespace Arkitektur.Business.Valdiators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad alanı boş bırakılamaz.")
                .MinimumLength(2).WithMessage("Ad Soyad en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ad Soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email alanı boş bırakılamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir email adresi giriniz.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")

            RuleFor(x => x.ServiceName)
                .NotEmpty().WithMessage("Lütfen bir hizmet seçiniz.")
                .MaximumLength(100).WithMessage("Hizmet adı 100 karakteri geçemez.");

            RuleFor(x => x.AppointmentDate)
                .NotEmpty().WithMessage("Randevu tarihi boş bırakılamaz.")
                .GreaterThan(DateTime.Now).WithMessage("Randevu tarihi bugünden ileri bir tarih olmalıdır.");

            RuleFor(x => x.Message)
                .MaximumLength(1000).WithMessage("Mesaj alanı en fazla 1000 karakter olabilir.");
        }
    }
}
