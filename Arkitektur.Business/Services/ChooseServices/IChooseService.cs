using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ChooseDtos;

namespace Arkitektur.Business.Services.ChooseServices
{
    public interface IChooseService
    {
        Task<BaseResult<List<ResultChooseDto>>> GetAllAsync();
        Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateChooseDto dto);
        Task<BaseResult<object>> UpdateAsync(UpdateChooseDto dto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
