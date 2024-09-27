using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystem.Database
{
    internal interface IMediaDatabase
    {
        // Add methods
        public void AddMedia(Media media);
        public void AddUserDetail(UserDetail userDetail);
        public void AddUserPassword(UserPasswordMapper userPasswordMapper);
        public void AddPersonalMedia(PersonalMedia personalMedia);
        public void AddReview(Review review);
        public void AddReaction(Reaction reaction);
        public void AddTag(Tag tag);
        public void AddTagInfo(TagInfo tagInfo);
        public void AddUserRating(UserRating userRating);
        public void AddAdmin(Admin admin);

        // Get methods
        public List<Media> GetMediaList();
        public List<UserPasswordMapper> GetUserPasswords();
        public List<UserDetail> GetUserDetails();
        public List<PersonalMedia> GetPersonalMediaList();
        public List<Review> GetReviewList();
        public List<Reaction> GetReactionList();
        public List<Tag> GetTagList();
        public List<TagInfo> GetTagInfoList();
        public List<UserRating> GetUserRatingList();
        public List<Admin> GetAdminList();
    }
}
