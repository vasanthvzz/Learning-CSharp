using MediaReviewSystemLibrary.Utils;
using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystem.View
{
    public class LoginUserView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintMenu("USER LOGIN ");
            //if (SessionManager.GetUser() != null)
            //{
            //    new MainMenuView().Initialize();
            //}
            //else
            //{
            GetUserDetail();
            //}
        }

        public void GetUserDetail()
        {
            Console.WriteLine("Enter your user name : ");
            string userName = Console.ReadLine();
            Console.WriteLine("Enter your password :");
            string password = ConsoleManager.GetPassword();
            LoginUser(userName, password);
        }

        public void LoginUser(string userName, string password)
        {

            LoginUserRequest req = new LoginUserRequest(userName, password);
            LoginUserPresenterCallBack res = new LoginUserPresenterCallBack(this);
            LoginUserUseCase uc = new LoginUserUseCase(req, res);
            uc.Execute();
        }

        private class LoginUserPresenterCallBack : ILoginUserPresenterCallback
        {
            LoginUserView _presenter;
            public LoginUserPresenterCallBack(LoginUserView presenter)
            {
                _presenter = presenter;
            }

            public void OnFailure(Exception e)
            {
                Console.WriteLine(e.Message);
                ConsoleManager.ViewEnd();
                new WelcomePageView().Initialize();
            }

            public void OnSuccess(ZResponse<LoginUserResponse> response)
            {
                LoginUserResponse res = response.Data;
                Console.WriteLine("User login successful");
                UserDetail userDetail = response.Data.UserDetail;
                SessionManager.SetUser(userDetail);
                if (response.Data.IsAdmin)
                {
                    new AdminMainMenuView().Initialize();
                }
                else
                {
                    new MainMenuView().Initialize();
                }
            }
        }
    }
}
