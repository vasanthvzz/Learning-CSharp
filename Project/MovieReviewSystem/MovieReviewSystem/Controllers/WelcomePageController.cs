
using MovieReviewSystem;
using MovieReviewSystem.Views;

internal class WelcomePageController
{
    private readonly UserDataManager _dataManager;
    IView? view;

    public WelcomePageController()
    {
        _dataManager = new UserDataManager();
    }

    public bool HandleChoice(string choice)   //Redirects to login and create account page
    {

        if (choice == "1")
        {
            view = new LoginPageView();
            view.Initialize();
            return true;
        }
        else if (choice == "2")
        {
            view = new CreateAccountView();
            view.Initialize();
            return true;
        }
        else
        {
            Console.WriteLine("Invalid Choice");
            return false;
        }
    }

    public void CreateUser(string userName, string password) // After creating account or account already exist it goes back to Welcome page
    {
        UserCredentialBObj userDTO = new UserCredentialBObj(userName, password);
        bool userAdded = _dataManager.AddUser(userDTO);
        if (userAdded)
        {
            Console.WriteLine("User has been added");
        }
        else
        {
            Console.WriteLine("User already exist. Please create a new account");
        }
        view = new WelcomePageView();
        view.Initialize();
    }

    public void LoginUser(string userName, string password) //After user logins he will be redirected to the main menu page. if not he will be redirect to Welcome page
    {
        bool isValid = _dataManager.LoginUser(userName, password);
        if (isValid)
        {
            SessionHandler.SetUser(_dataManager.GetUser(userName));
            view = new MainMenuView();
            view.Initialize();
        }
        else
        {
            Console.WriteLine("Wrong user name or  password");
            Console.WriteLine("Please try again");
            view = new WelcomePageView();
            view.Initialize();
        }
    }
}

