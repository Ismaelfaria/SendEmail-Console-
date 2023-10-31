using Send;
using System;
using System.Collections.Generic;
using System.Configuration;

string Provedor = ConfigurationManager.AppSettings["Provider"];
string UserMail = ConfigurationManager.AppSettings["UserMail"];
string Password = ConfigurationManager.AppSettings["Password"];
int.TryParse(ConfigurationManager.AppSettings["Port"], out var port);


try
{
    var send = new SendConfigure(Provedor, UserMail, Password, port);

    if (send.EhValido) { 
    send.SendMail(emailsTo: new List<string> { "limaismael4444@gmail.com" },
    subject: "Cheguei",
    body: "Sucesso de 100%"
    );
    Console.WriteLine("Sucesso");
    }
    else
    {
        Console.WriteLine("Erro: informações erradas");
    }
}
catch (ArgumentNullException err)
{
    Console.WriteLine("erro na validação do app.config dentro da classe InputInformation: " + err.Message);
}
catch (Exception err)
{
    Console.WriteLine("Erro desconhecido, ocorreu um erro tente mais tarde: " + err.Message);
}

