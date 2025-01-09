namespace Pureminds.Server;

public class RelevantQuestionEntityConfigurations : BaseEntityConfigurations<RelevantQuestion>
{
    public override void Configure(EntityTypeBuilder<RelevantQuestion> builder)
    {
        builder.ToTable("RelevantQuestions");
        base.Configure(builder);
    }
}
