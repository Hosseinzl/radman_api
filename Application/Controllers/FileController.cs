using Application.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileController : Controller
    {

        private readonly IFileRepository _fileRepository;
        public FileController(IFileRepository fileRepositroy,IWebHostEnvironment webHostEnvironment)
        {
            _fileRepository = fileRepositroy;
        }

        //[Authorize]
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected or empty.");
            }
            if (_fileRepository.ExistsByName(file.FileName))
            {
                ModelState.AddModelError("", "there is file with same name");
                return StatusCode(400, ModelState);
            }
            // Generate a unique ID for the file
            var status = await _fileRepository.AddFile(file);

            if (!status)
            {
                return BadRequest("File not uploaded.");
            }
            return Ok("successfully uploaded");
        }

        //[Authorize]
        [HttpGet("Download/{id}")]
        public async Task<IActionResult> GetFile(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (!_fileRepository.ExistsById(id))
            {
                return NotFound();
            }

            var file = await _fileRepository.GetFile(id);


            // Return the file as a file content result
            return File(file.content, "application/octet-stream", file.fileName);
        }

    }
}
