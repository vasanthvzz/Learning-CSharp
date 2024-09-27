using MediaReviewSystem.View;
using MediaReviewSystemLibrary.DataLoader;

class Program
{
    public static void Main(string[] args)
    {
        MainDL.Initialize();
        new WelcomePageView().Initialize();
    }
}