using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    internal class CreateUserView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintMenu("Create Account");
            GetAccountDetails();
        }

        public void GetAccountDetails()
        {
            Console.WriteLine("Enter user name : ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter password : ");
            string password = ConsoleManager.GetPassword();
            CreateAccount(userName, password);
        }

        private void CreateAccount(string userName, string password)
        {
            CreateUserRequest req = new CreateUserRequest(userName, password);
            CreateUserPresenterCallback callback = new CreateUserPresenterCallback(this);
            CreateUserUseCase useCase = new CreateUserUseCase(req, callback);
            useCase.Execute();
        }

        private class CreateUserPresenterCallback : ICallback<CreateUserResponse>
        {
            CreateUserView _presenter;
            public CreateUserPresenterCallback(CreateUserView view)
            {
                _presenter = view;
            }
            public void OnFailure(Exception exception)
            {
                Console.WriteLine(exception.Message);
                new WelcomePageView().Initialize();
            }

            public void OnSuccess(ZResponse<CreateUserResponse> response)
            {
                Console.WriteLine("Account has been created Successfully");
                new WelcomePageView().Initialize();
            }
        }

    }
}
