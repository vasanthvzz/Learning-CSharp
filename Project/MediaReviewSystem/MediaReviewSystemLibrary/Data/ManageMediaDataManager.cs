using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class ManageMediaDataManager : IManageMediaDataManager
    {
        private IMediaDatabase _db;

        public ManageMediaDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void UpdateMediaDetail(ManageMediaRequest request, ManageMediaUseCaseCallback callback)
        {

            try
            {
                if (request.UserMedia != null)
                {
                    long userId = request.UserId;
                    long mediaId = request.UserMedia.MediaId;
                    List<PersonalMedia> personalMediaList = _db.GetPersonalMediaList();
                    if (personalMediaList == null)
                    {
                        callback?.OnFailure(new Exception("Unable to find personal Media from the database"));
                    }

                    PersonalMedia personalMedia = personalMediaList.FirstOrDefault(personalMedia => personalMedia.UserId == userId && personalMedia.MediaId == mediaId);
                    if (personalMedia == null)
                    {
                        personalMedia = new PersonalMedia(userId, mediaId);
                        _db.AddPersonalMedia(personalMedia);
                    }

                    personalMedia.IsFavourite = request.UserMedia.IsFavourite;
                    personalMedia.HasWatched = request.UserMedia.HasWatched;
                    personalMedia.IsYetToWatch = request.UserMedia.IsYetToWatch;

                    List<UserRating> userRatingList = _db.GetUserRatingList();
                    if (userRatingList == null)
                    {
                        callback?.OnFailure(new Exception("Unable to find user rating from the database"));
                        return;
                    }

                    UserRating userRating = userRatingList.FirstOrDefault(userRating => userRating.UserId == userId && userRating.MediaId == mediaId);
                    if (userRating == null)
                    {
                        userRating = new UserRating(userId, mediaId);
                        _db.AddUserRating(userRating);
                    }

                    if (request.UserMedia.UserRating >= 1 && request.UserMedia.UserRating <= 10)
                    {
                        userRating.Score = request.UserMedia.UserRating;
                        Console.WriteLine("media rating updated successfully");
                    }

                    List<Reaction> reactionList = _db.GetReactionList();
                    if (reactionList == null)
                    {
                        callback?.OnFailure(new Exception("Unable to find user reaction table from the database"));
                        return;
                    }

                    Reaction userReaction = reactionList.FirstOrDefault(userReaction => userReaction.UserId == userId && userReaction.MediaId == mediaId);
                    if (userReaction == null)
                    {
                        userReaction = new Reaction(userId, mediaId);
                        _db.AddReaction(userReaction);
                    }
                    userReaction.MediaReaction = request.UserMedia.Reaction;
                }
                if (request.Review != null)
                {
                    Review review = new Review(request.UserId, request.UserMedia.MediaId, request.Review);
                    _db.AddReview(review);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

}
