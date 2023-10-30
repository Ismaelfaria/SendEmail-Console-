using Send;
using System;
using System.Collections.Generic;
using System.Configuration;

string Provedor = ConfigurationManager.AppSettings["Provider"];
string UserMail = ConfigurationManager.AppSettings["UserMail"];
string Password = ConfigurationManager.AppSettings["Password"];


try
{
    var send = new SendConfigure(Provedor, UserMail, Password);

    send.SendMail(emailsTo: new List<string> { "Destinatario" },
    subject: "Titulo",
    body: "Corpo"
    );
}
catch (ArgumentNullException err)
{
    Console.WriteLine("erro na validação do app.config dentro da classe InputInformation: " + err.Message);
}
catch (Exception err)
{
    Console.WriteLine("Erro desconhecido, ocorreu um erro tente mais tarde: " + err.Message);
}