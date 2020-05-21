using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cybersecurity_app
{
    public class EmailChecker
    {
        //Variable that contains all the characters that can be written in an email address
        private string emailCharacters = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

        public bool ValidEmailAddress { get; private set; }

        public bool CheckEmail(string email)
        {
            ValidEmailAddress = Regex.IsMatch(email, emailCharacters);
            return ValidEmailAddress;
        }

    }
}
