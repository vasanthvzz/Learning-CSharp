using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystemLibrary.Data
{
    public class LoginUserDataManager : ILoginUserDataManager
    {
        private IMediaDatabase _database;

        public LoginUserDataManager()
        {
            _database = MediaDatabase.GetDb();
        }

        public void ValidateUser(LoginUserRequest user, LoginUserUseCaseCallback useCaseCallback)
        {
            try
            {
                List<UserPasswordMapper> userPasswords = _database.GetUserPasswords();
                List<UserDetail> userDetails = _database.GetUserDetails();
                UserDetail userDetail = userDetails.FirstOrDefault(userDetail => userDetail.UserName == user.UserName);
                if (userDetail == null)
                {
                    useCaseCallback?.OnFailure(new Exception("User not found"));
                    return;
                }
                UserPasswordMapper userPasswordMapper = userPasswords.FirstOrDefault(userPasswordMapper => userPasswordMapper.UserId == userDetail.UserId);
                if (userPasswordMapper == null)
                {
                    useCaseCallback?.OnFailure(new Exception("Password not set"));
                    return;
                }
                if (AuthManager.VerifyPassword(user.Password, userPasswordMapper.Password))
                {

                    LoginUserResponse loginUserResponse = new LoginUserResponse(userDetail, AuthManager.IsAdmin(userDetail.UserId));
                    ZResponse<LoginUserResponse> zResponse = new ZResponse<LoginUserResponse>(loginUserResponse);
                    useCaseCallback?.OnSuccess(zResponse);
                }
                else
                {
                    useCaseCallback?.OnFailure(new Exception("Invalid password"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
