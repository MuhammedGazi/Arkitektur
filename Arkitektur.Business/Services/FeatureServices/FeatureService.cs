using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.FeatureDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.FeatureServices
{
    public class FeatureService(IGenericRepository<Feature> _repository,
                                IUnitOfWork _unitOfWork,
                                IValidator<Feature> _validator) : IFeatureService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateFeatureDto dto)
        {
            var feature = dto.Adapt<Feature>();
            var validation = await _validator.ValidateAsync(feature);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            await _repository.CreateAsync(feature);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(feature) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var feature = await _repository.GetByIdAsync(id);
            if (feature is null)
            {
                return BaseResult<object>.Fail("Feature Not Found");
            }
            _repository.Delete(feature);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(feature) : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultFeatureDto>>> GetAllAsync()
        {
            var features = await _repository.GetAllAsync();
            var result = features.Adapt<List<ResultFeatureDto>>();
            return BaseResult<List<ResultFeatureDto>>.Success(result);
        }

        public async Task<BaseResult<ResultFeatureDto>> GetByIdAsync(int id)
        {
            var feature = await _repository.GetByIdAsync(id);
            if (feature is null)
            {
                return BaseResult<ResultFeatureDto>.Fail("Feature Not Found");
            }
            var result = feature.Adapt<ResultFeatureDto>();
            return BaseResult<ResultFeatureDto>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateFeatureDto dto)
        {
            var feature = dto.Adapt<Feature>();
            var validation = await _validator.ValidateAsync(feature);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            _repository.Update(feature);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
