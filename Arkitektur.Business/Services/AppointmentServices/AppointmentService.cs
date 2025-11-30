using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public class AppointmentService(IGenericRepository<Appointment> appointmentRepository,
                                    IUnitOfWork unitOfWork,
                                    IValidator<Appointment> _validator)
                                    : IAppointmentService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateAppointmentDto dto)
        {
            var appointment = dto.Adapt<Appointment>();
            var validationResult = await _validator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            await appointmentRepository.CreateAsync(appointment);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(appointment) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var appointment = await appointmentRepository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult<object>.Fail("Appointment Not Found");
            }
            appointmentRepository.Delete(appointment);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync()
        {
            var appointments = await appointmentRepository.GetAllAsync();
            var result = appointments.Adapt<List<ResultAppointmentDto>>();
            return BaseResult<List<ResultAppointmentDto>>.Success(result);
        }

        public async Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id)
        {
            var appointment = await appointmentRepository.GetByIdAsync(id);
            if (appointment is null)
            {
                return BaseResult<ResultAppointmentDto>.Fail("Appointment Not Found");
            }
            var result = appointment.Adapt<ResultAppointmentDto>();
            return BaseResult<ResultAppointmentDto>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto dto)
        {
            var appointment = dto.Adapt<Appointment>();
            var validationResult = await _validator.ValidateAsync(appointment);
            if (!validationResult.IsValid)
            {
                return BaseResult<object>.Fail(validationResult.Errors);
            }
            appointmentRepository.Update(appointment);
            var result = await unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(result) : BaseResult<object>.Fail("Update Failed");
        }
    }
}
