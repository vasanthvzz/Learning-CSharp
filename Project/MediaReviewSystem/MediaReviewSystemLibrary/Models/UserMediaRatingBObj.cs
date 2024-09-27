namespace MediaReviewSystemLibrary.Models
{
    public class UserMediaRatingBObj
    {
        public long UserId { get; set; }
        public long MediaId { get; set; }
        public string MediaName { get; set; }
        public float MediaRating { get; set; }

        public UserMediaRatingBObj(long userId, long mediaId, string mediaName, float mediaRating)
        {
            UserId = userId;
            MediaId = mediaId;
            MediaName = mediaName;
            MediaRating = mediaRating;
        }
    }
}
