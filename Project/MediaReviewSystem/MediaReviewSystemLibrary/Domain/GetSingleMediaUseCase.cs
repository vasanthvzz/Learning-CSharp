using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Domain
{
    public class GetSingleMediaUseCase : UseCaseBase<GetSingleMediaResponse>
    {
        private readonly GetSingleMediaRequest _request;
        private readonly IGetSingleMediaDataManager _dm;
        public GetSingleMediaUseCase(GetSingleMediaRequest request, IGetSingleMediaPresenterCallback callback)
    : base(callback)
        {
            _request = request;
            _dm = new GetSingleMediaDataManager();
        }

        public override void Action()
        {
            _dm.GetSingleMedia(_request, new GetSingleMediaUseCaseCallback(this));
        }
    }

    public class GetSingleMediaRequest
    {
        public long MediaId { get; }
        public long UserId { get; }
        public GetSingleMediaRequest(long userId, long mediaId)
        {
            UserId = userId;
            MediaId = mediaId;
        }
    }

    public class GetSingleMediaResponse
    {
        public UserMediaBObj UserMedia { get; }
        public Media Media { get; }
        public List<MediaReviewBObj> Reviews { get; }
        public GetSingleMediaResponse(UserMediaBObj userMedia, Media media, List<MediaReviewBObj> reviews)
        {
            UserMedia = userMedia;
            Media = media;
            Reviews = reviews;
        }
    }

    public interface IGetSingleMediaDataManager
    {
        public void GetSingleMedia(GetSingleMediaRequest request, GetSingleMediaUseCaseCallback callback);
    }

    public class GetSingleMediaUseCaseCallback : ICallback<GetSingleMediaResponse>
    {
        private readonly GetSingleMediaUseCase _uc;
        public GetSingleMediaUseCaseCallback(GetSingleMediaUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnSuccess(ZResponse<GetSingleMediaResponse> response)
        {
            _uc.PresenterCallback?.OnSuccess(response);
        }
        public void OnFailure(Exception exception)
        {
            _uc.PresenterCallback?.OnFailure(exception);
        }
    }

    public interface IGetSingleMediaPresenterCallback : ICallback<GetSingleMediaResponse>
    { }
}
