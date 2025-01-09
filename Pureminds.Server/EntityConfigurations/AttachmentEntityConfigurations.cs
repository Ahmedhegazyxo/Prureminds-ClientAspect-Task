
namespace Pureminds.Server;

public class AttachmentEntityConfigurations : BaseEntityConfigurations<Attachment>
{
    public override void Configure(EntityTypeBuilder<Attachment> builder)
    {
        builder.ToTable("Attachments");
        base.Configure(builder);
    }
}
