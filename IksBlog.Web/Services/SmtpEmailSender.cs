using System.Net;
using System.Net.Mail;

namespace IksBlog.Web.Services;

public class SmtpEmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public SmtpEmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendAsync(string subject, string body)
    {
        var host = _configuration["Email:Host"] ?? throw new InvalidOperationException("Email:Host is not configured.");
        var port = int.Parse(_configuration["Email:Port"] ?? "587");
        var username = _configuration["Email:Username"];
        var password = _configuration["Email:Password"];
        var toAddress = _configuration["Email:ToAddress"] ?? throw new InvalidOperationException("Email:ToAddress is not configured.");

        using var client = new SmtpClient(host, port) { EnableSsl = true };
        if (!string.IsNullOrEmpty(username))
        {
            client.Credentials = new NetworkCredential(username, password);
        }

        var fromAddress = string.IsNullOrEmpty(username) ? toAddress : username;
        using var mail = new MailMessage(fromAddress, toAddress, subject, body);
        await client.SendMailAsync(mail);
    }
}
