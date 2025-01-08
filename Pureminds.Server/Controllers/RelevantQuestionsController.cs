namespace Pureminds.Server;

public class RelevantQuestionsController : BaseController<RelevantQuestion>
{
    IRelevantQuestionService _service;
    public RelevantQuestionsController(IRelevantQuestionService service) : base(service)
    {
        _service = service;
    }
}
