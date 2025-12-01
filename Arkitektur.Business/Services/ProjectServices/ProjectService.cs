using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;

namespace Arkitektur.Business.Services.ProjectServices
{
    public class ProjectService(IGenericRepository<Project> _repository,
                                IUnitOfWork _unitOfWork,
                                IValidator<Project> _validator)
                                : IProjectService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateProjectDto dto)
        {
            var category = dto.Adapt<Project>();
            var validation = await _validator.ValidateAsync(category);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            await _repository.CreateAsync(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(category) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                return BaseResult<object>.Fail("Category Not Found");
            }
            _repository.Delete(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
        {
            var category = await _repository.GetAllAsync();
            var result = category.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(result);
        }

        public async Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                return BaseResult<ResultProjectDto>.Fail("Category Not Found");
            }
            var result = category.Adapt<ResultProjectDto>();
            return BaseResult<ResultProjectDto>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto dto)
        {
            var category = dto.Adapt<Project>();
            var validation = await _validator.ValidateAsync(category);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            _repository.Update(category);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
