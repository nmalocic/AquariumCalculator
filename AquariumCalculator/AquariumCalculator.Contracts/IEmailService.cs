namespace AquariumCalculator.Contracts
{
  public interface IEmailService
  {
    void SendEmail(string toEmail, string subject, string text);
    void SendEmail(string toEmail, string fromEmail, string subject, string text);
    void SendEmail(string toEmail, string subject, string text, byte[] attachment);
    void SendEmail(string toEmail, string fromEmail, string subject, string text, byte[] attachemnt);
  }
}
