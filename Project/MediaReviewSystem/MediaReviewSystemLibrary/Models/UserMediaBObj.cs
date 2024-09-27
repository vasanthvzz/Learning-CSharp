using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystemLibrary.Models
{
    public class UserMediaBObj
    {
        public long MediaId { get; set; }
        public long UserId { get; set; }
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
        public ReactionType Reaction { get; set; }
        public float UserRating { get; set; }
        public List<MediaReviewBObj> mediaReviews { get; set; }

        public UserMediaBObj(Media media, List<MediaReviewBObj> mediaReviews)
        {
            MediaId = media.MediaId;
            this.mediaReviews = mediaReviews;
        }

        public UserMediaBObj(long mediaId, long userId, bool isFavourite, bool hasWatched, bool isYetToWatch, ReactionType reaction, float userRating)
        {
            MediaId = mediaId;
            UserId = userId;
            IsFavourite = isFavourite;
            HasWatched = hasWatched;
            Reaction = reaction;
            UserRating = userRating;
        }

        public UserMediaBObj(Media media, PersonalMedia personalMedia, UserRating userRating)
        {
            MediaId = media.MediaId;
            IsFavourite = personalMedia.IsFavourite;
            IsYetToWatch = personalMedia.IsYetToWatch;
            HasWatched = personalMedia.HasWatched;
            UserRating = userRating.Score;
            Reaction = ReactionType.NEUTRAL;
        }
    }
}
