using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.ProjectServices
{
    public class ProjectService(IGenericRepository<Project> _repository,
                                IUnitOfWork _unitOfWork,
                                IValidator<Project> _validator)
                                : IProjectService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateProjectDto dto)
        {
            var products = dto.Adapt<Project>();
            var validation = await _validator.ValidateAsync(products);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            await _repository.CreateAsync(products);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success(products) : BaseResult<object>.Fail("Create Failed");
        }

        public async Task<BaseResult<object>> DeleteAsync(int id)
        {
            var products = await _repository.GetByIdAsync(id);
            if (products is null)
            {
                return BaseResult<object>.Fail("Category Not Found");
            }
            _repository.Delete(products);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Delete Failed");
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            var result = products.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(result);
        }

        public async Task<BaseResult<ResultProjectDto>> GetByIdAsync(int id)
        {
            var products = await _repository.GetByIdAsync(id);
            if (products is null)
            {
                return BaseResult<ResultProjectDto>.Fail("Category Not Found");
            }
            var result = products.Adapt<ResultProjectDto>();
            return BaseResult<ResultProjectDto>.Success(result);
        }

        public async Task<BaseResult<List<ResultProjectDto>>> GetProjectsWithCategories()
        {
            var queryable = _repository.GetQueryable();
            var products = await queryable.Include(x => x.Category).ToListAsync();
            var result = products.Adapt<List<ResultProjectDto>>();
            return BaseResult<List<ResultProjectDto>>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateProjectDto dto)
        {
            var products = dto.Adapt<Project>();
            var validation = await _validator.ValidateAsync(products);
            if (!validation.IsValid)
            {
                return BaseResult<object>.Fail(validation.Errors);
            }
            _repository.Update(products);
            var result = await _unitOfWork.SaveChangesAsync();
            return result ? BaseResult<object>.Success() : BaseResult<object>.Fail("Update Failed");
        }
    }
}
