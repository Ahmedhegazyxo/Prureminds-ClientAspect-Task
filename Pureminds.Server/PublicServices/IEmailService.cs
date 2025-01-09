namespace Pureminds.Server;

public interface IEmailService
{
    Task<string> Send(MailEntity entity);
}
