using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystemLibrary.Data
{
    public class CreateUserDataManager : ICreateUserDataManager
    {

        private IMediaDatabase _db;

        public CreateUserDataManager()
        {
            _db = MediaDatabase.GetDb();
        }
        public void CreateUserAccount(CreateUserRequest user, CreateUserUseCaseCallback
            useCaseCallback)
        {
            try
            {
                List<UserDetail> userDetails = _db.GetUserDetails();
                List<UserPasswordMapper> userPasswords = _db.GetUserPasswords();
                if (userDetails == null || userPasswords == null)
                {
                    useCaseCallback?.OnFailure(new Exception("Unable to connect to data"));
                    return;
                }
                UserDetail userDetail = userDetails.FirstOrDefault(user1 => user1.UserName == user.UserName);
                if (userDetail != null)
                {
                    useCaseCallback?.OnFailure(new Exception("User name already exist"));
                }
                else
                {
                    long userId = IdentityManager.GenerateUniqueId();
                    _db.AddUserDetail(new UserDetail(userId, user.UserName));
                    string password = HashManager.HashPassword(user.Password);
                    _db.AddUserPassword(new UserPasswordMapper(userId, password));
                    CreateUserResponse response = new CreateUserResponse(true);
                    ZResponse<CreateUserResponse> res = new(response);
                    useCaseCallback?.OnSuccess(res);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
