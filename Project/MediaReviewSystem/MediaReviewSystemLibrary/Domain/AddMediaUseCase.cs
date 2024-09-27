using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Domain
{
    public class AddMediaUseCase : UseCaseBase<AddMediaResponse>
    {
        private IAddMediaDataManager _dm;
        private AddMediaRequest _request;

        public AddMediaUseCase(AddMediaRequest request, ICallback<AddMediaResponse> callback)
            : base(callback)
        {
            _request = request;
            _dm = new AddMediaDataManager();
        }

        public override void Action()
        {
            _dm.AddMedia(_request, new AddMediaUseCaseCallback(this));
        }
    }

    public class AddMediaUseCaseCallback : ICallback<AddMediaResponse>
    {
        private AddMediaUseCase _uc;

        public AddMediaUseCaseCallback(AddMediaUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnSuccess(ZResponse<AddMediaResponse> response)
        {
            _uc?.PresenterCallback.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc?.PresenterCallback.OnFailure(exception);
        }
    }

    public class AddMediaRequest
    {
        public Media Media { get; }
        public int[] Tags { get; }

        public AddMediaRequest(Media media, int[] tags)
        {
            Media = media;
            Tags = tags;
        }
    }

    public class AddMediaResponse
    {
        public long MediaId { get; set; } // ID of the added media

        public AddMediaResponse(long mediaId)
        {
            MediaId = mediaId;
        }
    }

    public interface IAddMediaDataManager
    {
        void AddMedia(AddMediaRequest request, AddMediaUseCaseCallback callback);
    }

    public interface IAddMediaPresenterCallback : ICallback<AddMediaResponse>
    {
    }
}
