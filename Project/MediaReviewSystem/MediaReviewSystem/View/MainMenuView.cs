using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class MainMenuView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintMenu("Main menu");
            ShowMenu();
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome " + SessionManager.GetUser().UserName);
            ConsoleManager.PrintTitle("Main Menu - Movie Review System");
            Console.WriteLine("1. View All Movie");
            Console.WriteLine("2. View my personal Media list");
            Console.WriteLine("3. View my movie reviews");
            Console.WriteLine("4. View my reacted movies");
            Console.WriteLine("5. View my rated movies");
            Console.WriteLine("6. Filter movies by Tags");
            Console.WriteLine("7. Search movies");
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
                    {
                        new GetAllMediaView().Initialize();
                        break;
                    }
                case "2":
                    {
                        new GetPersonalMediaView().Initialize();
                        break;
                    }
                case "3":
                    {
                        new GetUserReviewView().Initialize();
                        break;
                    }
                case "4":
                    {
                        new GetReactedMediaView().Initialize();
                        break;
                    }
                case "5":
                    {
                        new GetRatedMediaView().Initialize();
                        break;
                    }
                case "6":
                    {
                        new FilterMediaByTagView().Initialize();
                        break;
                    }
                case "7":
                    {
                        new SearchMediaView().Initialize();
                        break;
                    }
                case "0":
                    {
                        Logout();
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice");
                        break;
                    }
            }
            ConsoleManager.ViewEnd();
            Initialize();
        }

        private void Logout()
        {
            SessionManager.Clear();
            new WelcomePageView().Initialize();
        }
    }
}
