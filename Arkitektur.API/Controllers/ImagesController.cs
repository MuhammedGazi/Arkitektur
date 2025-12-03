using Arkitektur.Business.Services.FileServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Arkitektur.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController(IFileService fileService) : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> FileUpload(IFormFile file)
        {
            var response=await fileService.UploadImageToS3Async(file);
            return response.IsSuccessful ? Ok(response) : BadRequest(response);
        }
    }
}
