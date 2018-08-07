using AquariumCalculator.Contracts;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace AquariumCalculator.Services
{
  public class EmailService : IEmailService
  {
    private readonly string defaultFromEmail = "coderns@gmail.com";

    public void SendEmail(string toEmail, string subject, string body)
    {
      this.SendEmail(toEmail, defaultFromEmail, subject, body, null);
    }

    public void SendEmail(string toEmail, string fromEmail, string subject, string body)
    {
      this.SendEmail(toEmail, fromEmail, subject, body, null);
    }

    public void SendEmail(string toEmail, string subject, string body, byte[] attachment)
    {
      this.SendEmail(toEmail, defaultFromEmail, subject, body, attachment);
    }

    public void SendEmail(string toEmail, string fromEmail, string subject, string body, byte[] attachemnt)
    {
      var smptClient = new SmtpClient
      {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        Credentials = new NetworkCredential("coderns@gmail.com", "1fx9#Bc6*793")
      };

      using (var message = new MailMessage(new MailAddress(fromEmail, "Fish World DOO"), new MailAddress(toEmail))
      {
        Subject = subject,
        Body = body
      })
      {
        if(attachemnt != null) 
        {
          message.Attachments.Add(new Attachment(new MemoryStream(attachemnt), "Reefroome Invoice", "application/pdf"));
        }

        smptClient.Send(message);
      }

    }
  }
}
