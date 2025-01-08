namespace Pureminds.Server;

public class RelevantQuestionService : BaseService<RelevantQuestion>, IRelevantQuestionService
{
    public RelevantQuestionService(MigrationsDbContext context) : base(context)
    {
    }
}
