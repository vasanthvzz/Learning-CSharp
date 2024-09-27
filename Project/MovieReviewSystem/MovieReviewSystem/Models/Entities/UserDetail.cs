namespace MediaReviewSystemLibrary.Models.Entities
{
    public class UserDetail
    {
        public long UsertId { get; set; }
        public string UserName { get; set; }

        public UserDetail(long usertId, string userName)
        {
            UsertId = usertId;
            UserName = userName;
        }
    }
}
