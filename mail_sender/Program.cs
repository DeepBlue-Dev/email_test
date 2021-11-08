using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

namespace mail_sender
{
    class Program
    {
        static void Main(string[] args)
        {
            //  create confit for accessing the secrets.json file
            var mailconfig = new ConfigurationBuilder()
                                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                .AddJsonFile("appsettings.json")
                                .AddUserSecrets<Program>()
                                .Build();
            
            mailer test = new mailer(mailconfig);
            test.send_test_email();
            
        }

       

    }
}
