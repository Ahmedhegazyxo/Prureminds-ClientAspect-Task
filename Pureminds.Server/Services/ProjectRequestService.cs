
using Microsoft.EntityFrameworkCore;

namespace Pureminds.Server;

public class ProjectRequestService : BaseService<ProjectRequest>, IProjectRequestService
{
    MigrationsDbContext _context;
    IEmailService _emailService;
    IAttachmentService _attachmentService;
    public ProjectRequestService(MigrationsDbContext context, IEmailService emailService, IAttachmentService attachmentService) : base(context)
    {
        _emailService = emailService;
        _context = context;
        _attachmentService = attachmentService;
    }
    public override async Task<ProjectRequest> Create(ProjectRequest entity)
    {
        try
        {
            var transaction = _context.Database.BeginTransaction();
            try
            {
                Attachment? requestAttachment = entity.ProjectRequestAttachment;
                entity.ProjectRequestAttachment = null;
                if (requestAttachment is not null)
                {
                    Attachment attachment = await _attachmentService.Create(requestAttachment);
                    entity.AttachmentId = attachment.Id;
                }
                else
                {
                    entity = await base.Create(entity);
                }
                if (transaction is not null)
                {
                    await transaction.CommitAsync();
                }
                else
                    await transaction.RollbackAsync();
                await _emailService.Send(new MailEntity()
                {
                    SenderName = "Pure minds media",
                    RecipentEmail = entity.ClientEmail,
                    MailSubject = "Project Request Suggestion",
                    MailBody = $"Hi{entity.ClientName}, Thanks for delegating suggested project" +
                    $", Please follow up your e-mail or phone number ({entity.ClientPhoneNumber}) for further notice."

                });
                return entity;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Complain was not created");
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}
