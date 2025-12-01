using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.DataAccess.Repositories;
using Arkitektur.DataAccess.UOW;
using Arkitektur.Entity.Entities;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Arkitektur.Business.Services.CategoryServices
{
    public class CategoryService(IGenericRepository<Category> _repository,
                                 IUnitOfWork _unitOfWork,
                                 IValidator<Category> _validator)
                                 : ICategoryService
    {
        public async Task<BaseResult<object>> CreateAsync(CreateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
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

        public async Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync()
        {
            var category = await _repository.GetAllAsync();
            var result = category.Adapt<List<ResultCategoryDto>>();
            return BaseResult<List<ResultCategoryDto>>.Success(result);
        }

        public async Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
            {
                return BaseResult<ResultCategoryDto>.Fail("Category Not Fount");
            }
            var result = category.Adapt<ResultCategoryDto>();
            return BaseResult<ResultCategoryDto>.Success(result);
        }

        public async Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjects()
        {
            var categories = await _repository.GetQueryable().Include(x => x.Projects).ToListAsync();
            var result = categories.Adapt<List<ResultCategoriesWithProjectsDto>>();
            return BaseResult<List<ResultCategoriesWithProjectsDto>>.Success(result);
        }

        public async Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
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
