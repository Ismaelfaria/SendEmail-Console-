namespace Send
{
    public class Email : InputInformation
    {
        public Email(string provider, string userName, string password) : base(provider, userName, password)
        {
            this.Provider = provider;
            this.UserName = userName;
            this.Password = password;
        }
    }
}