using MovieReviewSystem.DataLoader;
using MovieReviewSystem.Views;

internal class Startup
{

    static void Main(string[] args)
    {
        MainDL.Initialize();
        MovieDatabase.GetDB();
        IView view = new WelcomePageView();
        view.Initialize();
    }
}