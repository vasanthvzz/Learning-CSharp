using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystem.Database
{
    public sealed class MediaDatabase : IMediaDatabase
    {
        private static MediaDatabase _db;
        private List<Media> _mediaList;
        private List<UserPasswordMapper> _passwordMapperList;
        private List<UserDetail> _userDetailList;
        private List<PersonalMedia> _personalMediaList;
        private List<Review> _reviewList;
        private List<Reaction> _reactionList;
        private List<Tag> _tagList;
        private List<TagInfo> _tagInfoList;
        private List<UserRating> _userRatingList;
        private List<Admin> _adminList;

        // Private constructor for singleton pattern
        private MediaDatabase()
        {
            _mediaList = new();
            _passwordMapperList = new();
            _userDetailList = new();
            _personalMediaList = new();
            _reviewList = new();
            _reactionList = new();
            _tagList = new();
            _tagInfoList = new();
            _userRatingList = new();
            _adminList = new();
        }

        // Singleton instance getter
        public static MediaDatabase GetDb()
        {
            if (_db == null)
            {
                _db = new MediaDatabase();
            }
            return _db;
        }

        // Add methods
        public void AddMedia(Media media) => _mediaList.Add(media);
        public void AddUserDetail(UserDetail userDetail) => _userDetailList.Add(userDetail);
        public void AddUserPassword(UserPasswordMapper userPassword) => _passwordMapperList.Add(userPassword);
        public void AddPersonalMedia(PersonalMedia personalMedia) => _personalMediaList.Add(personalMedia);
        public void AddReview(Review review) => _reviewList.Add(review);
        public void AddReaction(Reaction reaction) => _reactionList.Add(reaction);
        public void AddTag(Tag tag) => _tagList.Add(tag);
        public void AddTagInfo(TagInfo tagInfo) => _tagInfoList.Add(tagInfo);
        public void AddUserRating(UserRating userRating) => _userRatingList.Add(userRating);
        public void AddAdmin(Admin admin) => _adminList.Add(admin);

        // Get methods
        public List<Media> GetMediaList() => _mediaList;
        public List<UserDetail> GetUserDetails() => _userDetailList;
        public List<UserPasswordMapper> GetUserPasswords() => _passwordMapperList;
        public List<PersonalMedia> GetPersonalMediaList() => _personalMediaList;
        public List<Review> GetReviewList() => _reviewList;
        public List<Reaction> GetReactionList() => _reactionList;
        public List<Tag> GetTagList() => _tagList;
        public List<TagInfo> GetTagInfoList() => _tagInfoList;
        public List<UserRating> GetUserRatingList() => _userRatingList;
        public List<Admin> GetAdminList() => _adminList;
    }
}
