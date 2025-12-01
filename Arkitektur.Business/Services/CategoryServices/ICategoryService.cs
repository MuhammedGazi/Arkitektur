using Arkitektur.Business.Base;
using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.Business.DTOs.ProjectDtos;

namespace Arkitektur.Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<BaseResult<List<ResultCategoryDto>>> GetAllAsync();
        Task<BaseResult<List<ResultCategoriesWithProjectsDto>>> GetCategoriesWithProjects();
        Task<BaseResult<ResultCategoryDto>> GetByIdAsync(int id);
        Task<BaseResult<object>> CreateAsync(CreateCategoryDto dto);
        Task<BaseResult<object>> UpdateAsync(UpdateCategoryDto dto);
        Task<BaseResult<object>> DeleteAsync(int id);
    }
}
