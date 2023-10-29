namespace Send
{
    public class Mail : InputInformation
    {
        public Mail(string provider, string userName, string password) : base(provider, userName, password)
        {
            this.Provider = provider;
            this.UserName = userName;
            this.Password = password;
        }
    }
}