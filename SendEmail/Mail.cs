namespace Send
{
    public abstract class Mail
    {
        public string Provider { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }

        protected Mail(string provider, string userName, string password, int port)
        {
            Provider = provider;
            UserName = userName;
            Password = password;
            Port = port;
        }

        public bool EhValido
        {
            get
            {
                var providerValido = !string.IsNullOrEmpty(Provider);
                var emailValido = !string.IsNullOrEmpty(this.UserName);
                var senhaValida = !string.IsNullOrEmpty(this.Password);
                var portaValida = this.Port > 0;

                return providerValido && emailValido && senhaValida && portaValida;
            }
        }
    }
}