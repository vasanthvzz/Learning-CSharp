
internal class CreateAccountView : IView
{
    private readonly WelcomePageController _controller;

    public CreateAccountView()
    {
        _controller = new WelcomePageController();
    }

    public void Initialize()
    {
        Console.Clear();
        Writer.WriteTitle("Create Account");
        CreateAccountMenu();
    }

    public void CreateAccountMenu()
    {
        Console.WriteLine("Enter your User name : ");
        string userName = Console.ReadLine();
        Console.WriteLine("Enter your Password : ");
        string password = Console.ReadLine();
       _controller.CreateUser(userName, password);
    }

}

