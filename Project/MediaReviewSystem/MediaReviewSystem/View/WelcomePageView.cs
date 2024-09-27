using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class WelcomePageView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintTitle("\t\t Welcome To Movie Review System \t\t");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Create Account");
            GetChoice();
        }

        public void GetChoice()
        {
            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("Enter your Choice : ");
                string choice = Console.ReadLine();

                validChoice = RedirectChoice(choice);  // Await the result of RedirectChoiceAsync

                if (!validChoice && !ConsoleManager.InvalidChoice())
                {
                    Console.WriteLine("Exiting");
                    return;
                }
            }
        }

        public bool RedirectChoice(string choice)
        {
            IView view;
            if (choice == "1")
            {
                view = new LoginUserView();
                view.Initialize();
            }
            else if (choice == "2")
            {
                view = new CreateUserView();
                view.Initialize();
            }
            else
            {
                Console.WriteLine("Invalid option!");
                return false;
            }
            return true;
        }
    }
}

