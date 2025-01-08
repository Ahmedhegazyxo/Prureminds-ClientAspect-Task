namespace Pureminds.Server;

public class GeneralSettingEntityConfigurations : BaseEntityConfigurations<GeneralSetting>
{
    public override void Configure(EntityTypeBuilder<GeneralSetting> builder)
    {
        builder.ToTable("GeneralSettings");
        base.Configure(builder);
    }
}
