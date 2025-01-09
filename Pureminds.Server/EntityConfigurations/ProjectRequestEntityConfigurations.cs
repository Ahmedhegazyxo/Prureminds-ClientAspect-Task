namespace Pureminds.Server;

public class ProjectRequestEntityConfigurations : BaseEntityConfigurations<ProjectRequest>
{
    public override void Configure(EntityTypeBuilder<ProjectRequest> builder)
    {
        builder.ToTable("ProjectRequests");
        builder.HasOne(e => e.ProjectRequestAttachment).WithMany().HasForeignKey(e => e.AttachmentId);
        base.Configure(builder);
    }
}
