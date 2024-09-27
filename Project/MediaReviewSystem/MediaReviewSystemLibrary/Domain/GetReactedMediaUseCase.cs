using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Domain
{
    public class GetReactedMediaUseCase : UseCaseBase<GetReactedMediaResponse>
    {
        private IGetReactedMediaDataManager _dataManager;
        private GetReactedMediaRequest _request;

        public GetReactedMediaUseCase(GetReactedMediaRequest request, ICallback<GetReactedMediaResponse> callback) : base(callback)
        {
            _request = request;
            _dataManager = new GetReactedMediaDataManager();
        }

        public override void Action()
        {
            _dataManager.FetchData(_request, new GetReactedMediaUseCaseCallback(this));
        }
    }

    public class GetReactedMediaUseCaseCallback : ICallback<GetReactedMediaResponse>
    {
        private GetReactedMediaUseCase _useCase;

        public GetReactedMediaUseCaseCallback(GetReactedMediaUseCase useCase)
        {
            _useCase = useCase;
        }

        public void OnSuccess(ZResponse<GetReactedMediaResponse> response)
        {
            _useCase?.PresenterCallback.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _useCase?.PresenterCallback.OnFailure(exception);
        }
    }

    // Request and Response classes
    public class GetReactedMediaResponse
    {
        public List<CompactMediaBObj> LikedMedia { get; set; }
        public List<CompactMediaBObj> DislikedMedia { get; set; }
        public List<CompactMediaBObj> FunnyMedia { get; set; }
        public List<CompactMediaBObj> SadMedia { get; set; }
        public List<CompactMediaBObj> AngryMedia { get; set; }
        public List<CompactMediaBObj> FearMedia { get; set; }

        // Constructor to initialize all lists
        public GetReactedMediaResponse(List<CompactMediaBObj> likedMedia, List<CompactMediaBObj> dislikedMedia, List<CompactMediaBObj> funnyMedia,
            List<CompactMediaBObj> sadMedia, List<CompactMediaBObj> angryMedia, List<CompactMediaBObj> fearMedia)
        {
            LikedMedia = likedMedia;
            DislikedMedia = dislikedMedia;
            FunnyMedia = funnyMedia;
            SadMedia = sadMedia;
            AngryMedia = angryMedia;
            FearMedia = fearMedia;
        }
    }


    public class GetReactedMediaRequest
    {
        public long UserId { get; set; }

        public GetReactedMediaRequest(long userId)
        {
            UserId = userId;
        }
    }

    public interface IGetReactedMediaDataManager
    {
        void FetchData(GetReactedMediaRequest request, GetReactedMediaUseCaseCallback callback);
    }

    public interface IGetReactedMediaPresenterCallback : ICallback<GetReactedMediaResponse> { }
}
