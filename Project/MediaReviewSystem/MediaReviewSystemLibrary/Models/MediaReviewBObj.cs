namespace MediaReviewSystemLibrary.Models
{
    public class MediaReviewBObj
    {
        public long ReviewId { get; set; }
        public string UserName { get; set; }
        public string Review { get; set; }
        public DateTime Date { get; set; }

        public MediaReviewBObj(long reviewId, string userName, string review, DateTime date)
        {
            ReviewId = reviewId;
            UserName = userName;
            Review = review;
            Date = date;
        }
    }
}
