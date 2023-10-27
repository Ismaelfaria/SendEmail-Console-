using SendEmail;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;

string provedor = ConfigurationManager.AppSettings["EmailProvedor"];
string usuario = ConfigurationManager.AppSettings["EmailUsuario"];
string senha = ConfigurationManager.AppSettings["EmailSenha"];

Email outlook = new Email(provedor, usuario, senha);


outlook.SendEmail(
    emailsTo: new List<string>
    {
        "ismaellima89012@gmail.com"
    },
    subject: "test",
    body: "Segue o anexo"
    );
