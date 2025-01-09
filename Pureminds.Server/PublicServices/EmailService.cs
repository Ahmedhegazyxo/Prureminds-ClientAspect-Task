using System.Net;
using System.Net.Mail;

namespace Pureminds.Server;

public class EmailService : IEmailService
{
    public async Task<string> Send(MailEntity entity)
    {
        try
        {
            using (var client = new SmtpClient())
            {
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.Credentials = new NetworkCredential("2024lavish@gmail.com", "jtgwhaxbozenydlc");
                client.EnableSsl = true;

                var fromAddress = new MailAddress("2024lavish@gmail.com", "Lavish Support");
                var toAddress = new MailAddress(entity.RecipentEmail, entity.RecipentName);

                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = entity.MailSubject,
                    Body = $"test mail"
                };
                await client.SendMailAsync(message);
                return "success";
            }
        }
        catch(Exception exception)
        {
            await Console.Out.WriteLineAsync(exception.Message);
            throw exception;
        }
    }
}
