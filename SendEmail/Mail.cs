using System;

namespace Send
{
    public abstract class Mail : InputInformation
    {
        public Mail(string provider, string userName, string password)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

    }
}