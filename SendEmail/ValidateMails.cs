using System.Text.RegularExpressions;

namespace Send
{
    public class ValidateMails
    {
        public bool ValidateMail(string email)
        {
            Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (expression.IsMatch(email))
                return true;

            return false;
        }
    }
}
