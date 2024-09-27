namespace MediaReviewSystemLibrary.Models.Entities
{
    public class PersonalMedia
    {

        public PersonalMedia(long userId, long mediaId)
        {
            UserId = userId;
            MediaId = mediaId;
        }

        public long UserId { get; set; }
        public long MediaId { get; set; }
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
                    _hasWatched = false;
                }
            }
        }
        private bool _hasWatched;
        public bool HasWatched
        {
            get => _hasWatched;
            set
            {
                _hasWatched = value;
                if (_hasWatched)
                {
                    _isYetToWatch = false;
                }
            }
        }

    }
}
