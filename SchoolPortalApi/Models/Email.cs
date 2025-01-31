using MailKit.Security;
using MimeKit;

namespace SchoolPortalApi.Models
{
    public class Email
    {
        public static void SendEmail(string recieveremail, string recieverName, string subject, string body)
        {



            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("YRN University", "opesamuel863@gmail.com"));
            message.To.Add(new MailboxAddress(recieverName, recieveremail));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("opesamuel863@gmail.com", "kzjlzsopdvcmkppf");
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately (e.g., log or throw)
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
