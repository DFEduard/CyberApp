using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersecurity_app
{
    /// <summary>
    /// Class: User
    /// Write by: Florentin Eduard Decu
    /// Description: This class will store all the user's properties 
    /// </summary>
    public class User
    {
        //Private properties
        private int id;
        private string firstName;
        private string lastName;
        private string email;
        private string password;
        private bool multiFactorAuthentication; 
        //Public properties
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool MultiFactorAuthentication { get => multiFactorAuthentication; set => multiFactorAuthentication = value; }
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Parameterless constructor 
        /// </summary>
        public User()
        {

        }

        /// <summary>
        /// Constructor with parammeters. No user id as parameter. To be used when the user's id is unknown 
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="multiFactorAuthentication">If multi factor authentication is enable = True if disable = False</param>
        public User(string firstName, string lastName, string email, string password, bool multiFactorAuthentication)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            MultiFactorAuthentication = multiFactorAuthentication;
        }

        /// <summary>
        /// Constructor with parammeters
        /// </summary>
        /// <param name="id">User's id</param>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="email">User's email</param>
        /// <param name="password">User's password</param>
        /// <param name="multiFactorAuthentication">If multi factor authentication is enable = True if disable = False</param>
        public User(int id, string firstName, string lastName, string email, string password, bool multiFactorAuthentication)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            MultiFactorAuthentication = multiFactorAuthentication;
            Id = id;
        }

    }
}
