namespace Pureminds.Server;

public class ProvidedProvisionEntityConfigurations : BaseEntityConfigurations<ProvidedProvision>
{
    public override void Configure(EntityTypeBuilder<ProvidedProvision> builder)
    {
        builder.ToTable("ProvidedProvisions");
        base.Configure(builder);
    }
}
