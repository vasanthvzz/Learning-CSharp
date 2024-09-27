using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;

namespace MediaReviewSystemLibrary.Domain
{
    public class GetUserReviewUseCase : UseCaseBase<GetUserReviewResponse>
    {
        private IGetUserReviewDataManager _dm;
        private GetUserReviewRequest _request;
        public GetUserReviewUseCase(GetUserReviewRequest request, ICallback<GetUserReviewResponse> callback) : base(callback)
        {
            _request = request;
            _dm = new GetUserReviewDataManager();
        }

        public override void Action()
        {
            _dm.GetUserReview(_request, new GetUserReviewUseCaseCallback(this));
        }
    }

    public class GetUserReviewUseCaseCallback : ICallback<GetUserReviewResponse>
    {
        private GetUserReviewUseCase _uc;

        public GetUserReviewUseCaseCallback(GetUserReviewUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnSuccess(ZResponse<GetUserReviewResponse> response)
        {
            _uc?.PresenterCallback.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc?.PresenterCallback.OnFailure(exception);
        }
    }

    public class GetUserReviewResponse
    {
        public List<UserReviewBObj> UserReviews { get; set; }

        public GetUserReviewResponse(List<UserReviewBObj> userReviews)
        {
            UserReviews = userReviews;
        }
    }

    public class GetUserReviewRequest
    {
        public long UserId { get; set; }

        public GetUserReviewRequest(long userId)
        {
            UserId = userId;
        }
    }

    public interface IGetUserReviewDataManager
    {
        public void GetUserReview(GetUserReviewRequest request, GetUserReviewUseCaseCallback callback);
    }

    public interface IGetUserReviewPresenterCallback : ICallback<GetUserReviewResponse>

    {
    }
}
