namespace MediaReviewSystemLibrary.Models
{
    public class UserReviewBObj
    {
        public long ReviewId { get; set; }
        public string Description { get; set; }
        public string MediaName { get; set; }

        public UserReviewBObj(long reviewId, string description, string mediaName)
        {
            ReviewId = reviewId;
            Description = description;
            MediaName = mediaName;
        }
    }
}
