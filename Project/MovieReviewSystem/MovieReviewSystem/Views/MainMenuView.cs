using MovieReviewSystem.Controllers;

namespace MovieReviewSystem.Views
{
    internal class MainMenuView : IView
    {
        private readonly MainMenuController _controller;
        private IView? view;

        public MainMenuView()
        {
            _controller = new MainMenuController();
        }

        public void Initialize()
        {
            Console.Clear();
            Console.WriteLine("Welcome " + SessionHandler.GetUser().UserName);
            Writer.WriteTitle("Main Menu - Movie Review System");
            Console.WriteLine("1. View All Movie");
            Console.WriteLine("2. View A Movie(Add Comments)");
            Console.WriteLine("3. Rate a Movie");
            Console.WriteLine("4. Review a Movie");
            Console.WriteLine("5. React to Movies");
            Console.WriteLine("6. Manage my personal List");
            Console.WriteLine("7. Search/Filter Movie");
            Console.WriteLine("0. Logout");
            RedirectChoice();
        }

        public void RedirectChoice()
        {
            bool validChoice = false;
            while (!validChoice)
            {
                Console.WriteLine("Enter you Choice : ");
                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    view = new WelcomePageView();
                    view.Initialize();
                    return;
                }
                validChoice = _controller.HandleChoice(choice);
                if (!validChoice && !Writer.InvalidChoice())
                {
                    return;
                }
            }
            this.Initialize();
        }
    }
}
