using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrackMaster.Domain.Tasks;
using TrackMaster.Infrastructure.Services;

namespace TrackMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {
        IFileService _fileService;
        ITaskAttachmentRepository _taskAttachmentRepository;
        public AttachmentController(IFileService fileService,ITaskAttachmentRepository taskAttachmentRepository)
        {
            _fileService = fileService;
            _taskAttachmentRepository = taskAttachmentRepository;
        }
        [HttpPost]
        public async Task<IActionResult> UploadDocument(IFormFile formFile)
        {
            var filePath = await _fileService.SaveFile(formFile);

            if(filePath!=null)
            {
                var fileAttachment = await _taskAttachmentRepository.AddAttachment(filePath, formFile.ContentType);
                return Ok($"Uploaded Successfully. Reference Id: {fileAttachment.AttachmentId}");
            }
            else
            {
                return StatusCode(500, "Server Error.Please try again");
            }
            
        }
    }
}
