internal class LoginPageView : IView
{
    private readonly WelcomePageController _controller;

    public LoginPageView()
    {
        _controller = new WelcomePageController();
    }

    public void Initialize()
    {
        Console.Clear();
        Writer.WriteTitle("Login to your Account");
        GetCredential();

    }

    public void GetCredential()
    {
        Console.WriteLine("Enter User name : ");
        string userName = Console.ReadLine();
        Console.WriteLine("Enter password : ");
        string password = Console.ReadLine();
        _controller.LoginUser(userName, password);
    }

}