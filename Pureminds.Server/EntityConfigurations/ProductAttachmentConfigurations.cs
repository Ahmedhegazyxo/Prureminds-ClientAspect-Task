namespace Pureminds.Server;

public class ProductAttachmentConfigurations : BaseEntityConfigurations<ProductAttachment>
{
    public override void Configure(EntityTypeBuilder<ProductAttachment> builder)
    {
        builder.ToTable("ProductAttachments");
        base.Configure(builder);
    }
}
