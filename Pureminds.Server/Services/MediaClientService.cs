namespace Pureminds.Server;

public class MediaClientService : BaseService<MediaClient> , IMediaClientService
{
    public MediaClientService(MigrationsDbContext context) : base(context)
    {
    }
}   
