using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ContactDtos;

namespace Arkitektur.Business.Services.ContactServices
{
    public interface IContactService
    {
        Task<BaseResult<List<ResultContactDto>>> GetAllAsync();
        Task<BaseResult<ResultContactDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateContactDto dto);
        Task<BaseResult<object>> UpdateAsync(UpdateContactDto dto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
