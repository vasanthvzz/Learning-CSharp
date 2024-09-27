namespace MediaReviewSystemLibrary.Models
{
    public class UserCredentialBObj
    {
        public int UserId { get; }
        public string UserName { get; }

        public UserCredentialBObj(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }
    }
}
