using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieReviewSystem.Views
{

    internal class WelcomePageView : IView
    {
        private readonly WelcomePageController _controller;

        public WelcomePageView()
        {
            _controller = new WelcomePageController();
        }

        public void Initialize()
        {
            Writer.WriteTitle("\t\t Welcome To Movie Review System \t\t");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create Account");
            RedirectChoice();
        }

        public void RedirectChoice()
        {
            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("Enter you Choice : ");
                string choice = Console.ReadLine();
                validChoice = _controller.HandleChoice(choice);
                if (!validChoice && !Writer.InvalidChoice())
                {
                    Console.WriteLine("Exitting");
                    return;
                }
            }
        }
    }
}
