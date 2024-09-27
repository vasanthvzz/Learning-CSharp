using MovieReviewSystem.Models;
using MovieReviewSystem.Models.Entities;

internal class MovieDatabase
{
    private static MovieDatabase _db;

    // In-memory collections to hold data
    private List<User> _userList;
    private List<UserDetail> _userDetailList;
    private List<UserCredential> _userCredentialList;
    private List<Media> _mediaList;
    private List<Review> _reviewList;
    private List<PersonalMedia> _personalMediaList;
    private List<Reaction> _reactionList;
    private List<UserRating> _userRatingList;
    private List<Tag> _tagList;
    private List<TagInfo> _tagInfoList;
    private List<Actor> _actorList;
    private List<ActorInfo> _actorInfoList;
    private List<Comment> _commentList;
    private MovieDatabase()
    {
        // Initialize the lists
        _userList = new List<User>();
        _userDetailList = new List<UserDetail>();
        _userCredentialList = new List<UserCredential>();
        _mediaList = new List<Media>();
        _reviewList = new List<Review>();
        _personalMediaList = new List<PersonalMedia>();
        _reactionList = new List<Reaction>();
        _userRatingList = new List<UserRating>();
        _tagList = new List<Tag>();
        _tagInfoList = new List<TagInfo>();
        _actorList = new List<Actor>();
        _actorInfoList = new List<ActorInfo>();
        _commentList = new List<Comment>();
    }

    // Singleton pattern to ensure only one instance of the database is created
    public static MovieDatabase GetDB()
    {
        if (_db == null)
        {
            _db = new MovieDatabase();
        }
        return _db;
    }

    // Inserting Data
    public void AddUser(User user)
    {
        _userList.Add(user);
    }

    public void AddUserDetail(UserDetail userDetail)
    {
        _userDetailList.Add(userDetail);
    }

    public void AddUserCredential(UserCredential userCredential)
    {
        _userCredentialList.Add(userCredential);
    }

    public void AddMedia(Media media)
    {
        _mediaList.Add(media);
    }

    public void AddReview(Review review)
    {
        _reviewList.Add(review);
    }

    public void AddPersonalMedia(PersonalMedia personalMedia)
    {
        _personalMediaList.Add(personalMedia);
    }

    public void AddReaction(Reaction reaction)
    {
        _reactionList.Add(reaction);
    }

    public void AddUserRating(UserRating userRating)
    {
        _userRatingList.Add(userRating);
    }

    public void AddTag(Tag tag)
    {
        _tagList.Add(tag);
    }

    public void AddTagInfo(TagInfo tagInfo)
    {
        _tagInfoList.Add(tagInfo);
    }

    public void AddActor(Actor actor)
    {
        _actorList.Add(actor);
    }

    public void AddActorInfo(ActorInfo actorInfo)
    {
        _actorInfoList.Add(actorInfo);
    }

    public void AddComment(Comment comment)
    {
        _commentList.Add(comment);
    }

    public bool RemoveUser(User user) => _userList.Remove(user);
    public bool RemoveUserDetail(UserDetail userDetail) => _userDetailList.Remove(userDetail);
    public bool RemoveUserCredential(UserCredential userCredential) => _userCredentialList.Remove(userCredential);
    public bool RemoveMedia(Media media) => _mediaList.Remove(media);
    public bool RemoveReview(Review review) => _reviewList.Remove(review);
    public bool RemovePersonalMedia(PersonalMedia personalMedia) => _personalMediaList.Remove(personalMedia);
    public bool RemoveReaction(Reaction reaction) => _reactionList.Remove(reaction);
    public bool RemoveUserRating(UserRating userRating) => _userRatingList.Remove(userRating);
    public bool RemoveTag(Tag tag) => _tagList.Remove(tag);
    public bool RemoveTagInfo(TagInfo tagInfo) => _tagInfoList.Remove(tagInfo);
    public bool RemoveActor(Actor actor) => _actorList.Remove(actor);
    public bool RemoveActorInfo(ActorInfo actorInfo) => _actorInfoList.Remove(actorInfo);
    public bool RemoveComment(Comment comment) => _commentList.Remove(comment);

    // Retrieval methods
    public List<User> GetUserList() => _userList;
    public List<UserDetail> GetUserDetailList() => _userDetailList;
    public List<UserCredential> GetUserCredentials() =>_userCredentialList;
    public List<Media> GetMediaList() => _mediaList;
    public List<Review> GetReviewList() => _reviewList;
    public List<PersonalMedia> GetPersonalMediaList() => _personalMediaList;
    public List<Reaction> GetReactionList() => _reactionList;
    public List<UserRating> GetUserRatingList() => _userRatingList;
    public List<Tag> GetTagList() => _tagList;
    public List<TagInfo> GetTagInfoList() => _tagInfoList;
    public List<Actor> GetActorList() => _actorList;
    public List<ActorInfo> GetActorInfoList() => _actorInfoList;
    public List<Comment> GetCommentList() => _commentList;
}
