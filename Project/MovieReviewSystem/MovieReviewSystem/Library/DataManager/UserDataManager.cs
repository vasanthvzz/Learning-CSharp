
using MovieReviewSystem.Library.DataHandler;

internal class UserDataManager
{
    private readonly UserDataHandler _dataHandler;

    public UserDataManager()
    {
        _dataHandler = new UserDataHandler();
    }
    public bool AddUser(UserCredentialBObj userLoginDTO)
    {
        string userName = userLoginDTO.UserName;
        User user = _dataHandler.GetByUserName(userName);
        if (user == null)
        {
            _dataHandler.Add(userLoginDTO);
            return true;
        }
        return false;
    }

    public User GetUser(string userName)
    {
        return _dataHandler.GetByUserName(userName);
    }

    public string GetUserName(int userId)
    {
        User user = _dataHandler.GetById(userId);
        return _dataHandler.GetById(userId).UserName;
    }

    public bool LoginUser(string userName, string password)
    {
        User user = _dataHandler.GetByUserName(userName);
        if (user == null || user.Password != password)
        {
            return false;
        }
        return true;
    }
}

