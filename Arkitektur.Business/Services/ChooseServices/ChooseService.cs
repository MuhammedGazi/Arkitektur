using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ChooseDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ChooseServices
{
    public class ChooseService(IGenericRepository<Choose> _repository,
                                IUnitOfWork _unitOfWork,
                                IValidator<Choose> _validator) : IChooseService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateChooseDto dto)
        {
            var choose = dto.Adapt<Choose>();
            var validation = await _validator.ValidateAsync(choose);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            await _repository.CreateAsync(choose);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(result) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var choose = await _repository.GetByIdAsync(id);
            if (choose is null)
            {
                return BaseResult<object>.Fail("Choose Not Found");
            }
            _repository.Delete(choose);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultChooseDto>>> GetAllAsync()
        {
            var chooses = await _repository.GetAllAsync();
            var result = chooses.Adapt<List<ResultChooseDto>>();
            return BaseResult<List<ResultChooseDto>>.Success(result);
        }

        public async Task<BaseResult<ResultChooseDto>> GetByIdAsync(int id)
        {
            var choose = await _repository.GetByIdAsync(id);
            if (choose is null)
            {
                return BaseResult<ResultChooseDto>.Fail("Choose Not Found");
            }
            var result = choose.Adapt<ResultChooseDto>();
            return BaseResult<ResultChooseDto>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateChooseDto dto)
        {
            var choose = dto.Adapt<Choose>();
            var validation = await _validator.ValidateAsync(choose);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            _repository.Update(choose);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
