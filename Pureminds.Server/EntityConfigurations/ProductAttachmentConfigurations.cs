namespace Pureminds.Server;

public class ProductAttachmentConfigurations : BaseEntityConfigurations<ProductAttachment>
{
    public override void Configure(EntityTypeBuilder<ProductAttachment> builder)
    {
        builder.ToTable("ProductAttachments");
        builder.HasOne(e => e.Attachment).WithMany().HasForeignKey(e => e.AttachmentId);
        base.Configure(builder);
    }
}
