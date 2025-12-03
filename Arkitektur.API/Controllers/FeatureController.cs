using Arkitektur.Business.DTOs.FeatureDtos;
using Arkitektur.Business.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController(IFeatureService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultFeatureDto>>> GetAll()
        {
            var response = await _service.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultFeatureDto>> GetById(int id)
        {
            var response = await _service.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFeatureDto dto)
        {
            var response = await _service.CreateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateFeatureDto dto)
        {
            var response = await _service.UpdateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
