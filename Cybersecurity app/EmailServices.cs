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
        protected string email = ;
        protected string password = ;
        protected SmtpClient smtpClient;

        public EmailServices()
        {
            smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(email,password),
                Timeout = 20000
            };
        }

        public void SendEmail(string toEmail)
        {
            using (var msg = new MailMessage(email, toEmail))
            {
                msg.Subject = "CODE";
                msg.Body = "TESTING";

                smtpClient.Send(msg);
            }
        }
    }
}
