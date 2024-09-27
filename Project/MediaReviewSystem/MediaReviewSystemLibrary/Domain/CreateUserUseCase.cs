using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;

namespace MediaReviewSystemLibrary.Domain
{
    //Create user use case
    public class CreateUserUseCase : UseCaseBase<CreateUserResponse>
    {
        private readonly CreateUserDataManager _dm;
        private readonly CreateUserRequest _request;

        public CreateUserUseCase(CreateUserRequest req, ICallback<CreateUserResponse> callback) : base(callback)
        {
            _request = req;
            _dm = new CreateUserDataManager();
        }

        //Define action method
        public override void Action()
        {
            _dm.CreateUserAccount(_request, new CreateUserUseCaseCallback(this));
        }
    }

    //Define use case callback class
    public class CreateUserUseCaseCallback : ICallback<CreateUserResponse>
    {
        private readonly CreateUserUseCase _uc;
        public CreateUserUseCaseCallback(CreateUserUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnFailure(Exception exception)
        {
            _uc.PresenterCallback?.OnFailure(exception);
        }

        public void OnSuccess(ZResponse<CreateUserResponse> response)
        {
            _uc.PresenterCallback?.OnSuccess(response);
        }
    }


    //Interface for Create user datamanager
    public interface ICreateUserDataManager
    {
        public void CreateUserAccount(CreateUserRequest user, CreateUserUseCaseCallback useCaseCallback);
    }

    //Create user request
    public class CreateUserRequest
    {
        public string UserName { get; }
        public string Password { get; }
        public CreateUserRequest(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }

    //Create user response
    public class CreateUserResponse
    {
        public bool Success { get; }
        public CreateUserResponse(bool success) { Success = success; }
    }
}
