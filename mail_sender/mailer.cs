using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.Extensions.Configuration;


namespace mail_sender
{
    class mailer
    {
        private readonly IConfiguration Configuration;

        public mailer(IConfiguration config)
        {
            Configuration = config;
        }

        public void send_test_email()
        {
            MimeMessage msg = new MimeMessage();
            msg.From.Add(new MailboxAddress("AB", "test@test.com"));
            msg.To.Add(new MailboxAddress("loremipsumdolorsitamet", "loremipsum@dolorsit.amet")); //    change this to an actual email
            msg.Subject = "this is a test";
            msg.Body = new TextPart("plain")
            {
                Text = "this is a test, if you got this... well good job you"
            };

            using(SmtpClient mail_client = new SmtpClient())
            {
                mail_client.Connect("smtp.gmail.com", 587, false);
                mail_client.Authenticate(Configuration["email"].ToString(), Configuration["password"].ToString());  //  extract password and username from the secrets.json
                mail_client.Send(msg);
                mail_client.Disconnect(true);
            }
            
        }

    }
}
