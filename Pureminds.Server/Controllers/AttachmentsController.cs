namespace Pureminds.Server;

public class AttachmentsController : BaseController<Attachment>
{
    IAttachmentService _service;
    public AttachmentsController(IAttachmentService service) : base(service)
    {
        _service = service;
    }
}
