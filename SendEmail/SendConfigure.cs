﻿using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Send
{
    public class SendConfigure : Mail
    {
        public SendConfigure(string provider, string userName, string password, int port) : base(provider, userName, password, port)
        {
            this.Provider = provider;
            this.UserName = userName;
            this.Password = password;
            this.Port = port;
        }
        

        /// <summary>
        /// Usado para enviar o email
        /// </summary>
        /// <param name="emailsTo">Lista de endereços de e-mail dos destinatários.</param>
        /// <param name="subject">Assunto do e-mail.</param>
        /// <param name="body">Corpo do e-mail.</param>
        public void SendMail(List<string> emailsTo, string subject, string body)
        {
            var message = PrepareteMail(emailsTo, subject, body);

            SendMailBySmtp(message);
        }

        /// <summary>
        /// Preparar o email para a configuração
        /// </summary>
        private MailMessage PrepareteMail(List<string> mailsTo, string subject, string body)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(UserName);

            foreach (var mmail in mailsTo)
            {
                var v = new ValidateMails();
                if (v.ValidateMail(mmail))
                {
                    mail.To.Add(mmail);
                }
            }

            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;


            return mail;
        }

        /// <summary>
        /// Usado para enviar o email
        /// </summary>
        /// <param name="message">Instancia do preparador de email</param>

        private void SendMailBySmtp(MailMessage message)
        {
            var port = int.TryParse(ConfigurationManager.AppSettings["Port"], out var porta);
            
            var smtpClient = new SmtpClient(Provider);
            smtpClient.Host = Provider;
            smtpClient.Port = porta;
            smtpClient.EnableSsl = true;
            smtpClient.Timeout = 50000;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(UserName, Password);
            smtpClient.Send(message);
            smtpClient.Dispose();
        }
      
    }
}
