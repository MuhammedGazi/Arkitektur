using Arkitektur.Business.DTOs.BannerDtos;
using Arkitektur.Business.Services.BannerServices;
using Microsoft.AspNetCore.Mvc;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController(IBannerService _bannerService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultBannerDto>>> GetAll()
        {
            var response = await _bannerService.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultBannerDto>> GetById(int id)
        {
            var response = await _bannerService.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto dto)
        {
            var response = await _bannerService.CreateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _bannerService.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto dto)
        {
            var response = await _bannerService.UpdateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
