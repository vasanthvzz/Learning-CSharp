namespace MediaReviewSystemLibrary.Models.Entities
{
    public class Review
    {

        public Review(int userId, int mediaId, string description)
        {
            UserId = userId;
            MediaId = mediaId;
            Description = description;
            Datetime = DateTime.Now;
            //ReviewId = "R" + ++ReviewCounter;
        }

        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public int MediaId { get; set; }
        public string Description { get; set; }
        public DateTime Datetime { get; set; }
    }

}
