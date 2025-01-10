namespace Pureminds.Server;

public class ProjectRequestsController : BaseController<ProjectRequest>
{
    IProjectRequestService _service;
    public ProjectRequestsController(IProjectRequestService service) : base(service)
    {
        _service = service;
    }
    [HttpGet("GetProjectRequestWithIncludes/{id}")]
    public async Task<ProjectRequest> GetProjectRequestWithIncludes(int id)
    {
        try
        {
            return await _service.ReadByIdWithIncludes(id);
        }
        catch(Exception exception)
        {
            throw exception;
        }
    }
}
