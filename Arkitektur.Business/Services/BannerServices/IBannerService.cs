using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.BannerDtos;

namespace Arkitektur.Business.Services.BannerServices
{
    public interface IBannerService
    {
        Task<BaseResult<List<ResultBannerDto>>> GetAllAsync();
        Task<BaseResult<ResultBannerDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateBannerDto dto);
        Task<BaseResult<object>> UpdateAsync(UpdateBannerDto dto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
