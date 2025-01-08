namespace Pureminds.Server;

public class MediaClientEntityConfigurations : BaseEntityConfigurations<MediaClient>
{
    public override void Configure(EntityTypeBuilder<MediaClient> builder)
    {
        builder.ToTable("MediaClients");
        base.Configure(builder);
    }
}
