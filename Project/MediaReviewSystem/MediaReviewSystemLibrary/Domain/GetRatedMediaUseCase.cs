using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;

namespace MediaReviewSystemLibrary.Domain
{
    public class GetRatedMediaUseCase : UseCaseBase<GetRatedMediaResponse>
    {
        private IGetRatedMediaDataManager _dm;
        private GetRatedMediaRequest _request;
        public GetRatedMediaUseCase(GetRatedMediaRequest request, ICallback<GetRatedMediaResponse> callback) : base(callback)
        {
            _request = request;
            _dm = new GetRatedMediaDataManager();
        }

        public override void Action()
        {
            _dm.GetRatedMedia(_request, new GetRatedMediaUseCaseCallback(this));
        }
    }

    public class GetRatedMediaUseCaseCallback : ICallback<GetRatedMediaResponse>
    {
        private GetRatedMediaUseCase _uc;

        public GetRatedMediaUseCaseCallback(GetRatedMediaUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnSuccess(ZResponse<GetRatedMediaResponse> response)
        {
            _uc?.PresenterCallback.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc?.PresenterCallback.OnFailure(exception);
        }
    }

    public class GetRatedMediaResponse
    {
        public List<UserMediaRatingBObj> RatedMedia { get; set; }

        public GetRatedMediaResponse(List<UserMediaRatingBObj> ratedMedia)
        {
            RatedMedia = ratedMedia;
        }
    }

    public class GetRatedMediaRequest
    {
        public long UserId { get; set; }

        public GetRatedMediaRequest(long userId)
        {
            UserId = userId;
        }
    }

    public interface IGetRatedMediaDataManager
    {
        void GetRatedMedia(GetRatedMediaRequest request, GetRatedMediaUseCaseCallback callback);
    }

    public interface IGetRatedMediaPresenterCallback : ICallback<GetRatedMediaResponse>
    {
    }
}
