using System.Text.RegularExpressions;

namespace Send
{
    public class ValidateMails
    {
        /// <summary>
        /// Usado validar a nomeclatura dos emails.
        /// </summary>
        /// <param name="mail">Email a ser analizado</param>
        public bool ValidateMail(string mail)
        {
            Regex expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");
            if (expression.IsMatch(mail))
                return true;

            return false;
        }
    }
}
