namespace Pureminds.Server;

public class AttachmentService : BaseService<Attachment>, IAttachmentService
{
    public AttachmentService(MigrationsDbContext context) : base(context)
    {
    }
}
