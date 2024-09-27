using CommonClassLibrary;
using MediaReviewSystem.Database;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Data
{
    public class GetUserReviewDataManager : IGetUserReviewDataManager
    {
        private IMediaDatabase _db;

        public GetUserReviewDataManager()
        {
            _db = MediaDatabase.GetDb();
        }

        public void GetUserReview(GetUserReviewRequest request, GetUserReviewUseCaseCallback callback)
        {
            try
            {
                if (_db == null)
                {
                    callback?.OnFailure(new Exception("Unable to connect to the database"));
                    return;
                }
                List<Review> reviews = _db.GetReviewList();
                List<Review> userReviewList = reviews.Where(review => review.UserId == request.UserId).ToList();
                List<UserReviewBObj> userReviews = new List<UserReviewBObj>();
                foreach (Review review in userReviewList)
                {
                    long mediaId = review.MediaId;
                    Media media = _db.GetMediaList().FirstOrDefault(media => media.MediaId == mediaId);
                    if (media == null)
                    {
                        callback?.OnFailure(new Exception("Interanal error : Review for non existent Media exist"));
                        return;
                    }
                    UserReviewBObj userReview = new UserReviewBObj(review.ReviewId, review.Description, media.Name);
                    userReviews.Add(userReview);
                }
                GetUserReviewResponse response = new GetUserReviewResponse(userReviews);
                ZResponse<GetUserReviewResponse> zResponse = new ZResponse<GetUserReviewResponse>(response);
                callback?.OnSuccess(zResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
