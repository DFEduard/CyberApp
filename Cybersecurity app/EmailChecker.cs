using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cybersecurity_app
{
    /// <summary>
    /// Class: EmailChecker
    /// Write by: Florentin Eduard Decu
    /// Description: This class will check if an email is valid or invalid
    /// </summary>
    public class EmailChecker
    {
        //Variable that contains all the characters that can be written in an email address
        private string emailCharacters = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        //Public property to check the email validation result 
        public bool ValidEmailAddress { get; private set; }

        /// <summary>
        /// Method used to check the email validation
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool CheckEmail(string email)
        {
            //Check the email 
            ValidEmailAddress = Regex.IsMatch(email, emailCharacters);
            //Return true or false 
            return ValidEmailAddress;
        }

    }
}
