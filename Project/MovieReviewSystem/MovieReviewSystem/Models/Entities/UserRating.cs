namespace MediaReviewSystemLibrary.Models.Entities
{
    public class UserRating
    {
        public int UserId { get; set; }
        public int MediaId { get; set; }
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
        public UserRating(int userId, int mediaId)
        {
            UserId = userId;
            MediaId = mediaId;
        }
    }
}
