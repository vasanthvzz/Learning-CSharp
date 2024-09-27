using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class AdminMainMenuView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintMenu("Admin panel ");
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.WriteLine("1. Add movie");
            Console.WriteLine("0. Logout");
            RedirectChoice();
        }

        private void RedirectChoice()
        {
            Console.WriteLine("Enter your choice ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    new AddMediaView().Initialize();
                    break;

                case "0":
                    Logout();
                    return;

                default:
                    Console.WriteLine("Invalid option !");
                    break;
            }
            ShowMenu();
        }

        private void Logout()
        {
            new WelcomePageView().Initialize();
        }
    }
}
