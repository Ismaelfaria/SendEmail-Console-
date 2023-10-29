using Send;
using System.Collections.Generic;
using System.Configuration;

string Provedor = ConfigurationManager.AppSettings["Provider"];
string UserMail = ConfigurationManager.AppSettings["UserMail"];
string Password = ConfigurationManager.AppSettings["Password"];


var gmail = new Email(Provedor, UserMail, Password);

var send = new SendConfigure(Provedor, UserMail, Password);


send.SendEmail(emailsTo: new List<string> { "ismaellima89012@gmail.com" },
subject: "test",
body: "Segue o anexo"
);
