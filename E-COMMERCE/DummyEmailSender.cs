using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using System.Diagnostics;


public class DummyEmailSender : IEmailSender
{
   

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // مجرد عرض للإيميل في الـ Output/Console
        Debug.WriteLine($"To: {email}");
        Debug.WriteLine($"Subject: {subject}");
        Debug.WriteLine($"Message: {htmlMessage}");
        return Task.CompletedTask;
    }
}