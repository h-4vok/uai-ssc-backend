using SSC.Business.Interfaces;
using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business
{
    public class SmtpHandler : ISmtpHandler
    {
        public SmtpHandler()
        {
            this.Port = 25;
            this.UseDefaultCredentials = false;
            this.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public int Port { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string HostName { get; set; }
        public SmtpDeliveryMethod DeliveryMethod { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool EnableSsl { get; set; }

        public void Send(QueuedMail mail, bool isBodyHtml = false)
        {
            var mailMessage = this.CreateMailMessage(mail);
            mailMessage.IsBodyHtml = isBodyHtml;
            this.CreateSmtpClient(mailMessage);
        }

        internal void CreateSmtpClient(MailMessage message)
        {
            using (var client = new SmtpClient())
            {
                client.Port = this.Port;
                client.Host = this.HostName;
                client.UseDefaultCredentials = this.UseDefaultCredentials;
                client.DeliveryMethod = this.DeliveryMethod;
                client.EnableSsl = this.EnableSsl;

                if (!this.UseDefaultCredentials)
                {
                    client.Credentials = new NetworkCredential(this.UserName, this.Password);
                }

                client.Send(message);
            }
        }

        internal MailMessage CreateMailMessage(QueuedMail message)
        {
            var output = new MailMessage();

            output.From = new MailAddress("no-reply@ssc.com");

            Action<string, Action<string>> setReceivers = (input, actionOnProperty) =>
            {
                var splitted = input.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                splitted.ForEach(receiver => actionOnProperty(receiver));
            };

            setReceivers(message.To, output.To.Add);
            setReceivers(message.Cc, output.CC.Add);
            setReceivers(message.Bcc, output.Bcc.Add);

            output.Subject = message.Subject;
            output.Body = message.Body;

            return output;
        }
    }
}
