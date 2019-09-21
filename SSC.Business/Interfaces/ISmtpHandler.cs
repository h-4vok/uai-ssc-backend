using SSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SSC.Business.Interfaces
{
    public interface ISmtpHandler
    {
        int Port { get; set; }
        bool UseDefaultCredentials { get; set; }
        string HostName { get; set; }
        SmtpDeliveryMethod DeliveryMethod { get; set; }
        void Send(QueuedMail mail, bool isBodyHtml);
        string UserName { get; set; }
        string Password { get; set; }
    }
}
