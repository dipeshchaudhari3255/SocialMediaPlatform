using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocialMediaPlatform.Helper
{
    public class EmailService
    {
        public static async Task SendEmailAsync(string email, string subject, string htmlString)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                    {
                        Port = 587,
                        EnableSsl = true,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("dipeshchaudhari3255@gmail.com", "ikrg mlto kote jhlr"), // Use app-specific password
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    };

                    message.From = new MailAddress("dipeshchaudhari3255@gmail.com");
                    message.To.Add(new MailAddress(email));
                    message.Subject = subject;
                    message.IsBodyHtml = true;
                    message.Body = htmlString;

                    await smtp.SendMailAsync(message); // Async call
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"Error sending email: {ex.Message}");
                throw; // Optionally rethrow or handle it more gracefully
            }
        }
    }
}