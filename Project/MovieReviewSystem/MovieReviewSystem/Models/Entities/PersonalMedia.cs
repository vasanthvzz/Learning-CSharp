namespace MediaReviewSystemLibrary.Models.Entities
{
    public class PersonalMedia
    {

        public PersonalMedia(int userId, int mediaId)
        {
            UserId = userId;
            MediaId = mediaId;
        }

        public int UserId { get; set; }
        public int MediaId { get; set; }
        public bool IsFavourite { get; set; }
        private bool _isYetToWatch;
        public bool IsYetToWatch
        {
            get => _isYetToWatch;
            set
            {
                _isYetToWatch = value;
                if (_isYetToWatch)
                {
                    _isWatched = false;
                }
            }
        }
        private bool _isWatched;
        public bool IsWatched
        {
            get => _isWatched;
            set
            {
                _isWatched = value;
                if (_isWatched)
                {
                    _isYetToWatch = false;
                }
            }
        }

    }
}
