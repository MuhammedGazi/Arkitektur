using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.AppointmentDtos;

namespace Arkitektur.Business.Services.AppointmentServices
{
    public interface IAppointmentService
    {
        Task<BaseResult<List<ResultAppointmentDto>>> GetAllAsync();
        Task<BaseResult<ResultAppointmentDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateAppointmentDto dto);
        Task<BaseResult<object>> UpdateAsync(UpdateAppointmentDto dto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
