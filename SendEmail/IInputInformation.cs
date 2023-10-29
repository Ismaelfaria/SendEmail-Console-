using System;

namespace Send
{
    public abstract class InputInformation
    {
        public string Provider { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public InputInformation(string provider, string userName, string password)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }
    }
}
