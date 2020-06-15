using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace Cybersecurity_app
{
    public class EmailServices
    {
        protected string email = "";
        protected string password = "";
        protected SmtpClient smtpClient;
        private Encryption encryption = new Encryption();

        public EmailServices()
        {
            smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(encryption.DecryptData(email),encryption.DecryptData(password)),
                Timeout = 20000
            };
        }

        public void SendEmail(string toEmail,string message)
        {
            using (var msg = new MailMessage(encryption.DecryptData(email),toEmail))
            {
                msg.Subject = "Multi Factor Authentication NO REPLY";
                msg.IsBodyHtml = true;
                msg.Body = "Your unique code is: <h1>"+message+"</h1>";

                smtpClient.Send(msg);
            }
        }
    }
}
