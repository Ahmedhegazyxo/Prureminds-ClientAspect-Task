namespace Pureminds.Server;

public class ProvidedProvisionService : BaseService<ProvidedProvision>, IProvidedProvisionService
{
    public ProvidedProvisionService(MigrationsDbContext context) : base(context)
    {
    }
}
