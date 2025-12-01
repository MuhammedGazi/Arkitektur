using Arkitektur.Business.DTOs.CategoryDtos;
using Arkitektur.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultCategoryDto>>> GetAll()
        {
            var response = await _categoryService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("WithProjects")]
        public async Task<ActionResult<List<ResultCategoryDto>>> GetCategoriesWithWithProjects()
        {
            var response = await _categoryService.GetCategoriesWithProjects();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultCategoryDto>> GetById(int id)
        {
            var response = await _categoryService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var response = await _categoryService.CreateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            var response = await _categoryService.UpdateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
