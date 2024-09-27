using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;

namespace MediaReviewSystemLibrary.Domain
{
    public class GetPersonalMediaUseCase : UseCaseBase<GetPersonalMediaResponse>
    {
        private IGetPersonalMediaDataManager _dm;
        private GetPersonalMediaRequest _req;

        public GetPersonalMediaUseCase(GetPersonalMediaRequest request, IGetPersonalMediaPresenterCallback callback) : base(callback)
        {
            _req = request;
            _dm = new GetPersonalMediaDataManager();
        }

        public override void Action()
        {
            _dm.GetPesonalMediaList(_req, new GetPersonalMediaUseCaseCallback(this));
        }
    }

    public class GetPersonalMediaResponse
    {
        public List<CompactMediaBObj> FavouriteMedia { get; set; }
        public List<CompactMediaBObj> HasWatchedMedia { get; set; }
        public List<CompactMediaBObj> YetToWatchMedia { get; set; }

        public GetPersonalMediaResponse()
        {
            FavouriteMedia = new List<CompactMediaBObj>();
            HasWatchedMedia = new List<CompactMediaBObj>();
            YetToWatchMedia = new List<CompactMediaBObj>();
        }
    }

    public class GetPersonalMediaRequest
    {
        public long UserId { get; }
        public GetPersonalMediaRequest(long userId)
        {
            UserId = userId;
        }
    }

    public class GetPersonalMediaUseCaseCallback : ICallback<GetPersonalMediaResponse>
    {
        private GetPersonalMediaUseCase _uc;
        public GetPersonalMediaUseCaseCallback(GetPersonalMediaUseCase useCase)
        {
            _uc = useCase;
        }
        public void OnSuccess(ZResponse<GetPersonalMediaResponse> response)
        {
            _uc?.PresenterCallback.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine(exception);
        }

    }
    public interface IGetPersonalMediaDataManager
    {
        void GetPesonalMediaList(GetPersonalMediaRequest req, GetPersonalMediaUseCaseCallback useCaseCallback);
    }

    public interface IGetPersonalMediaPresenterCallback : ICallback<GetPersonalMediaResponse> { }
}

