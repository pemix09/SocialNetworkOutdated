﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public class EmailSender 
    {
        public void SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string fromMail = "socialnetworkpolibuda@gmail.com";
            string fromPassword = "SocialNetwork123%";

            MailMessage message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(new MailAddress(email));
            message.Body = "<html><body> " + htmlMessage + " </body></html>";
            message.IsBodyHtml = true;

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true,
            };
            //smtpClient.Send(message);
        }
    }
}
