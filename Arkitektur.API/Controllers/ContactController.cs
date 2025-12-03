using Arkitektur.Business.DTOs.ContactDtos;
using Arkitektur.Business.Services.ContactServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController(IContactService _service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<ResultContactDto>>> GetAll()
        {
            var response=await _service.GetAllAsync();
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultContactDto>> GetById(int id)
        {
            var response=await _service.GetByIdAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateContactDto dto)
        {
            var response=await _service.CreateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response=await _service.DeleteAsync(id);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateContactDto dto)
        {
            var response=await _service.UpdateAsync(dto);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
