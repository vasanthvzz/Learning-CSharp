using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystemLibrary.Models.Entities
{
    public class Review
    {
        public long ReviewId { get; set; }
        public long UserId { get; set; }
        public long MediaId { get; set; }
        public string Description { get; set; }
        public DateTime Datetime { get; set; }

        public Review(long userId, long mediaId, string description)
        {
            ReviewId = IdentityManager.GenerateUniqueId();
            UserId = userId;
            MediaId = mediaId;
            Description = description;
            Datetime = DateTime.Now;
        }
    }

}
