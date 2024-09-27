namespace MediaReviewSystemLibrary.Models.Entities
{
    public class Admin
    {
        public long UserId { get; set; }

        public Admin(long userId)
        {
            UserId = userId;
        }
    }
}
