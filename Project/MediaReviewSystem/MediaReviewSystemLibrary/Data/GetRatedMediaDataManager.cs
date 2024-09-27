using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class GetRatedMediaDataManager : IGetRatedMediaDataManager
    {
        private IMediaDatabase _db;

        public GetRatedMediaDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void GetRatedMedia(GetRatedMediaRequest request, GetRatedMediaUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }

                List<UserRating> ratingList = _db.GetUserRatingList();
                List<Media> mediaList = _db.GetMediaList();
                if (ratingList == null || mediaList == null)
                {
                    callback?.OnFailure(new Exception("Unable to fetch data from the database"));
                    return;
                }

                //Fetch user rating that match the user id and user rating > 1
                long userId = request.UserId;
                List<UserRating> userRatings = ratingList.Where(rating => rating.UserId == userId &&
                                                                rating.Score >= 1).ToList();

                //get the media name from the media id and store it in the user media rating object
                List<UserMediaRatingBObj> ratedMediaList = new List<UserMediaRatingBObj>();
                foreach (UserRating rating in userRatings)
                {
                    string mediaName = _db.GetMediaList().FirstOrDefault(media => media.MediaId == rating.MediaId).Name;
                    UserMediaRatingBObj userMediaRating = new UserMediaRatingBObj(userId, rating.MediaId, mediaName, rating.Score);
                    ratedMediaList.Add(userMediaRating);

                }
                //Create response and send to the callback
                GetRatedMediaResponse response = new GetRatedMediaResponse(ratedMediaList);
                ZResponse<GetRatedMediaResponse> zResponse = new ZResponse<GetRatedMediaResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
