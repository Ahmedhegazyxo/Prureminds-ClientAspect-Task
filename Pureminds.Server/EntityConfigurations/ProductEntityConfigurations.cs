namespace Pureminds.Server;

public class ProductEntityConfigurations : BaseEntityConfigurations<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasMany(e=>e.ProductAttachments).WithOne().HasForeignKey(e => e.ProductId);
        base.Configure(builder);
    }
}
