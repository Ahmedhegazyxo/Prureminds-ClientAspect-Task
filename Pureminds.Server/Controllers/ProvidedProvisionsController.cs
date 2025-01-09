namespace Pureminds.Server;

public class ProvidedProvisionsController : BaseController<ProvidedProvision>
{
    IProvidedProvisionService _service;
    public ProvidedProvisionsController(IProvidedProvisionService service) : base(service)
    {
        _service = service;
    }
}
