using MovieReviewSystem.Library.DataHandler.Contracts;
using SQLite;
using System.Data;

namespace MovieReviewSystem.Library.DataHandler
{
    internal class UserDataHandler : IUserDataHandler
    {
        private MovieDatabase _database;

        public UserDataHandler()
        {
            _database = MovieDatabase.GetDB();
        }

        public User GetByUserName(string userName)
        {
            var query = _database.GetUserList().Where(user => user.UserName == userName);
            return query.FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return _database.GetUserList();
        }

        public User GetById(int id)
        {
            var query = _database.GetUserList().Where(item => item.UserId == id);
            return query.FirstOrDefault();
        }

        public void Update(User entity)
        {
            User user = GetById(entity.UserId);
            user.UserName = entity.UserName;
            user.Password = entity.Password;
        }

        public void Add(UserCredentialBObj userDTO)
        {
            User user = new User(userDTO.UserName, userDTO.Password);
            _database.AddUser(user);
        }

    }

}
