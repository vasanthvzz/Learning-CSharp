namespace MovieReviewSystem.Library.DataHandler.Contracts
{
    internal interface IUserDataHandler
    {
        public User GetByUserName(string userName);
        public List<User> GetAll();
        public User GetById(int id);
        public void Update(User entity);
        public void Add(UserCredentialBObj userDTO);
    }
}
