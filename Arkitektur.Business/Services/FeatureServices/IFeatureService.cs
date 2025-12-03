using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.FeatureDtos;

namespace Arkitektur.Business.Services.FeatureServices
{
    public interface IFeatureService
    {
        Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync();
        Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateFeatureDto dto);
        Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto dto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
