namespace Pureminds.Server;

public class ProductEntityConfigurations : BaseEntityConfigurations<Product>
{
    public override void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        base.Configure(builder);
    }
}
