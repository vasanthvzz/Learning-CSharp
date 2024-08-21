using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDemo
{
    internal class EmailLGenerator
    {
        public void SendEmailToUser(object sender, UserArgs e)
        {
            Console.WriteLine("Email sent to user : " + e.Name);
        }
    }
}
