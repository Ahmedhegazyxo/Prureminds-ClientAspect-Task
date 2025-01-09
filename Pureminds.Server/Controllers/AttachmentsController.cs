namespace Pureminds.Server;

public class AttachmentsController : BaseController<Attachment>
{
    IAttachmentService _service;
    public AttachmentsController(IAttachmentService service) : base(service)
    {
        _service = service;
    }
    [HttpGet("download/{id}")]
    public async Task<IActionResult> DownloadAttachment(int id)
    {
        try
        {
            var mimeTypes = new Dictionary<string, string>
        {
            { ".pdf", "application/pdf" },
            { ".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { ".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
            { ".txt", "text/plain" },
            { ".csv", "text/csv" },
            { ".jpg", "image/jpeg" },
            { ".png", "image/png" },
            { ".zip", "application/zip" }
        };

            Attachment? attachment = await _service.ReadById(id);

            if (attachment == null)
            {
                return NotFound("Attachment not found.");
            }

            var fileExtension = Path.GetExtension(attachment.FileType).ToLowerInvariant();
            var fileType = mimeTypes.ContainsKey(fileExtension) ? mimeTypes[fileExtension] : "application/octet-stream";

            var stream = new MemoryStream(attachment.Content);

            return File(stream, fileType, attachment.FileName);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
