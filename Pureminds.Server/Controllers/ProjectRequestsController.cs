namespace Pureminds.Server;

public class ProjectRequestsController : BaseController<ProjectRequest>
{
    IProjectRequestService _service;
    public ProjectRequestsController(IProjectRequestService service) : base(service)
    {
        _service = service;
    }
}
