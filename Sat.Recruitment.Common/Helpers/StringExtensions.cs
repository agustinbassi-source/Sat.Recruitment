using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Sat.Recruitment.Common.Helpers
{
    public static class StringExtensions
    {
        public static bool IsEmail(this string email)
        {
            try
            {
                MailAddress test = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static string NormalizeEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return email;

            var normalized = RemoveCharactersAndSpaces(email.Substring(0, email.IndexOf("@"))) + email.Substring(email.IndexOf("@"));
 
            return normalized;
        }

        private static string RemoveCharactersAndSpaces(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Replace(".", string.Empty);
            text = text.Replace(" ", string.Empty);
            return text.Trim();
        }

    }
}
