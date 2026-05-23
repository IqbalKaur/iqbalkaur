namespace IksBlog.Web.Services;

public interface IEmailSender
{
    Task SendAsync(string subject, string body);
}
