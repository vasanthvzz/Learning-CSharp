using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Domain
{
    public class LoginUserUseCase : UseCaseBase<LoginUserResponse>
    {
        private ILoginUserDataManager _dm;
        private LoginUserRequest _req;

        public LoginUserUseCase(LoginUserRequest req, ILoginUserPresenterCallback callback) : base(callback)
        {
            _req = req;
            _dm = new LoginUserDataManager();
        }

        public override void Action()
        {
            _dm.ValidateUser(_req, new LoginUserUseCaseCallback(this));
        }
    }

    // Callback for Use Case
    public class LoginUserUseCaseCallback : ICallback<LoginUserResponse>
    {
        private LoginUserUseCase _uc;

        public LoginUserUseCaseCallback(LoginUserUseCase uc)
        {
            _uc = uc;
        }

        public void OnFailure(Exception error)
        {
            _uc?.PresenterCallback?.OnFailure(error);
        }

        public void OnSuccess(ZResponse<LoginUserResponse> response)
        {
            _uc?.PresenterCallback?.OnSuccess(response);
        }
    }

    // Interface for Data Manager (User Validation)
    public interface ILoginUserDataManager
    {
        void ValidateUser(LoginUserRequest request, LoginUserUseCaseCallback useCaseCallback);
    }

    // Models for Login Request and Response
    public class LoginUserRequest
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginUserRequest(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }

    public class LoginUserResponse
    {
        public bool IsAdmin { get; }
        public UserDetail UserDetail { get; }

        public LoginUserResponse(UserDetail userDetail, bool isAdmin = false)
        {
            UserDetail = userDetail;
            IsAdmin = isAdmin;
        }
    }

    // Presenter Callback Interface for Login Use Case
    public interface ILoginUserPresenterCallback : ICallback<LoginUserResponse> { }
}
