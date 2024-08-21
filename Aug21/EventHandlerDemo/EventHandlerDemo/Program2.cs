using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandlerDemo
{
    internal class Program2
    {
        static void Main()
        {
            Database db = new Database();
            IDCardGenerator id = new IDCardGenerator();
            EmailLGenerator eg = new EmailLGenerator();

            UserProcessor.UserProcessorEvent += db.SaveToDb;
            UserProcessor.UserProcessorEvent += id.GenerateCard;
            UserProcessor.UserProcessorEvent += eg.SendEmailToUser;

            Console.WriteLine("Commands accepted");
            Console.WriteLine("1. New : Add new user");
            Console.WriteLine("2. Exit : close the application");
            string cmdInput;
            while (true)
            {
                Console.WriteLine("Enter command");
                cmdInput = Console.ReadLine();
                if (cmdInput == "2")
                {
                    break;
                }
                else if (cmdInput == "1")
                {
                    Console.Write("Enter user name : ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter user age : ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Email sending needed? (y/n)");
                    string emailNeeded = Console.ReadLine();
                    if (emailNeeded.Equals("n"))
                    {
                        UserProcessor.UserProcessorEvent -= eg.SendEmailToUser;
                    }
                    UserProcessor.ProcessUser(name, age);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }
        }
    }
}
