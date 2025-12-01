using Arkitektur.Business.DTOs.ProjectDtos;
using Arkitektur.Business.Services.ProjectServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService _projectService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultProjectDto>>> GetAll()
        {
            var response = await _projectService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("WithCategories")]
        public async Task<ActionResult<List<ResultProjectDto>>> GetProjectsWithCategories()
        {
            var response = await _projectService.GetProjectsWithCategories();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultProjectDto>> GetById(int id)
        {
            var response = await _projectService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectDto dto)
        {
            var response = await _projectService.CreateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _projectService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProjectDto dto)
        {
            var response = await _projectService.UpdateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
