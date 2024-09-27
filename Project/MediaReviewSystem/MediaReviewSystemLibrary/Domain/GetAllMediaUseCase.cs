using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Domain
{
    public class GetAllMediaUseCase : UseCaseBase<GetAllMediaResponse>
    {
        private IGetAllMediaDataManager _dm = new GetAllMediaDataManager();

        public GetAllMediaUseCase(GetAllMediaRequest req, IGetAllMediaPresenterCallback callback) : base(callback)
        {

        }

        public override void Action()
        {
            _dm.GetAllMedia(new GetAllMediaUseCaseCallback(this));
        }
    }

    public class GetAllMediaUseCaseCallback : ICallback<GetAllMediaResponse>
    {
        private GetAllMediaUseCase _uc;

        public GetAllMediaUseCaseCallback(GetAllMediaUseCase uc)
        {
            _uc = uc;
        }

        public void OnFailure(Exception error)
        {
            Console.WriteLine(error.Message);
        }

        public void OnSuccess(ZResponse<GetAllMediaResponse> response)
        {
            _uc.PresenterCallback?.OnSuccess(response);
        }
    }

    public interface IGetAllMediaDataManager
    {
        void GetAllMedia(ICallback<GetAllMediaResponse> callback);
    }

    public class GetAllMediaRequest
    {

    }

    public class GetAllMediaResponse
    {
        public GetAllMediaResponse(List<CompactMediaBObj> mediaList)
        {
            MediaList = mediaList;
        }
        public List<CompactMediaBObj> MediaList { get; }
    }

    public interface IGetAllMediaPresenterCallback : ICallback<GetAllMediaResponse>
    {

    }
}
