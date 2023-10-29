using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Send
{
    public class SendConfigure : Email
    {
        public SendConfigure(string provider, string userName, string password) : base(provider, userName, password)
        {
            this.Provider = provider;
            this.UserName = userName;
            this.Password = password;
        }

        public void SendEmail(List<string> emailsTo, string subject, string body)
        {
            var message = PrepareteMail(emailsTo, subject, body);

            SendEmailBySmtp(message);
        }


        private MailMessage PrepareteMail(List<string> emailsTo, string subject, string body)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(UserName);

            foreach (var email in emailsTo)
            {
                var v = new ValidateMails();
                if (v.ValidateMail(email))
                {
                    mail.To.Add(email);
                }
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;


            return mail;
        }

        private void SendEmailBySmtp(MailMessage message)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.Host = Provider;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(UserName, Password);
            smtpClient.Send(message);
            smtpClient.Dispose();
        }
    }
}
