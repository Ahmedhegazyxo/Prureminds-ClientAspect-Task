
namespace Pureminds.Server;

public class ProjectRequestService : BaseService<ProjectRequest>, IProjectRequestService
{
    IEmailService _emailService;
    public ProjectRequestService(MigrationsDbContext context, IEmailService emailService) : base(context)
    {
        _emailService = emailService;
    }
    public override async Task<ProjectRequest> Create(ProjectRequest entity)
    {
        try
        {
            await _emailService.Send(new MailEntity()
            {
                SenderName = "Pure minds media",
                RecipentEmail = entity.ClientEmail,
                MailSubject = "Project Request Suggestion",
                MailBody = $"Hi{entity.ClientName}, Thanks for delegating suggested project" +
                $", Please follow up your e-mail or phone number ({entity.ClientPhoneNumber}) for further notice."

            });
            return await base.Create(entity);
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}
