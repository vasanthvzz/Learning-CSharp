using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class GetSingleMediaDataManager : MediaDataManagerBase, IGetSingleMediaDataManager
    {
        private IMediaDatabase _db;

        public GetSingleMediaDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void GetSingleMedia(GetSingleMediaRequest request, GetSingleMediaUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Database connection is not established"));
                    return;
                }
                List<Media> mediaList = _db.GetMediaList();
                if (mediaList == null)
                {
                    callback?.OnFailure(new Exception("unable to fetch data from the database"));
                    return;
                }
                Media media = mediaList.FirstOrDefault(media => media.MediaId == request.MediaId);
                if (media == null)
                {
                    callback?.OnFailure(new Exception("Movie not found !"));
                    return;
                }
                List<PersonalMedia> personalMediaList = _db.GetPersonalMediaList();
                long userId = request.UserId;
                PersonalMedia personalMedia = personalMediaList.FirstOrDefault(personalMedia => personalMedia.MediaId == media.MediaId && personalMedia.UserId == request.UserId);
                if (personalMedia == null)
                {
                    personalMedia = new PersonalMedia(request.UserId, media.MediaId);
                    _db.AddPersonalMedia(personalMedia);
                }
                List<UserRating> userRatingList = _db.GetUserRatingList();
                UserRating userRating = userRatingList.FirstOrDefault(userRating => userRating.UserId == request.UserId && userRating.MediaId == media.MediaId);
                if (userRating == null)
                {
                    userRating = new UserRating(request.UserId, media.MediaId);
                    _db.AddUserRating(userRating);
                }

                List<Reaction> reactionList = _db.GetReactionList();
                Reaction reaction = reactionList.FirstOrDefault(reaction => reaction.UserId == request.UserId && reaction.MediaId == media.MediaId);
                if (reaction == null)
                {
                    reaction = new Reaction(userId, media.MediaId);
                    _db.AddReaction(reaction);
                }

                List<Review> reviewList = _db.GetReviewList().Where(review => review.MediaId == request.MediaId).ToList();
                List<MediaReviewBObj> mediaReviews = new List<MediaReviewBObj>();
                foreach (Review review in reviewList)
                {
                    UserDetail user = _db.GetUserDetails().FirstOrDefault(user => user.UserId == review.UserId);
                    if (user == null)
                    {
                        callback?.OnFailure(new Exception("Internal error : Comment without user exist"));
                        return;
                    }
                    MediaReviewBObj mediaReview = new MediaReviewBObj(review.ReviewId, user.UserName, review.Description, review.Datetime);
                    mediaReviews.Add(mediaReview);
                }
                UserMediaBObj userMedia = new UserMediaBObj(media, personalMedia, userRating);
                GetSingleMediaResponse response = new GetSingleMediaResponse(userMedia, media, mediaReviews);
                ZResponse<GetSingleMediaResponse> zResponse = new ZResponse<GetSingleMediaResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
