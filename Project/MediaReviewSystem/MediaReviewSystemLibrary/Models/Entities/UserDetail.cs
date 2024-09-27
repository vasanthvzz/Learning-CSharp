namespace MediaReviewSystemLibrary.Models.Entities
{
    public class UserDetail
    {
        public long UserId { get; set; }
        public string UserName { get; set; }

        public UserDetail(long usertId, string userName)
        {
            UserId = usertId;
            UserName = userName;
        }
    }
}
