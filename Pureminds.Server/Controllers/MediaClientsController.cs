namespace Pureminds.Server;

public class MediaClientsController : BaseController<MediaClient>
{
    IMediaClientService _service;
    public MediaClientsController(IMediaClientService service) : base(service)
    {
        _service = service;
    }
}
