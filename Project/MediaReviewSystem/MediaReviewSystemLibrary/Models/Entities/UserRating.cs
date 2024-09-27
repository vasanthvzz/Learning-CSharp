namespace MediaReviewSystemLibrary.Models.Entities
{
    public class UserRating
    {
        public long UserId { get; set; }
        public long MediaId { get; set; }
        private float _score;
        public float Score
        {
            get
            {
                return _score;
            }
            set
            {
                if (value <= 10 && value >= 1)
                {
                    _score = value;
                }
                else
                {
                    throw new Exception("Invalid rating score");
                }
            }
        }
        public UserRating(long userId, long mediaId)
        {
            UserId = userId;
            MediaId = mediaId;
        }
    }
}
