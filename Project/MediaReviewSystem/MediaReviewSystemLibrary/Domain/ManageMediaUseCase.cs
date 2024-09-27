using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;

namespace MediaReviewSystemLibrary.Domain
{
    public class ManageMediaUseCase : UseCaseBase<ManageMediaResponse>
    {
        private readonly ManageMediaRequest _request;
        private readonly IManageMediaDataManager _dm;

        public ManageMediaUseCase(ManageMediaRequest request, ICallback<ManageMediaResponse> callback) : base(callback)
        {
            _request = request;
            _dm = new ManageMediaDataManager();
        }

        public override void Action()
        {
            _dm.UpdateMediaDetail(_request, new ManageMediaUseCaseCallback(this));
        }
    }

    public class ManageMediaRequest
    {
        public string Review { get; }
        public UserMediaBObj UserMedia { get; }
        public long UserId { get; }
        public ManageMediaRequest(long userId, string review, UserMediaBObj userMedia)
        {
            UserId = userId;
            Review = review;
            UserMedia = userMedia;
        }
    }

    public class ManageMediaResponse
    {
        public UserMediaBObj UserMedia { get; }
        public ManageMediaResponse(UserMediaBObj userMedia)
        {
            UserMedia = userMedia;
        }
    }

    public interface IManageMediaDataManager
    {
        public void UpdateMediaDetail(ManageMediaRequest request, ManageMediaUseCaseCallback callback);
    }

    public class ManageMediaUseCaseCallback : ICallback<ManageMediaResponse>
    {
        private ManageMediaUseCase _uc;
        public ManageMediaUseCaseCallback(ManageMediaUseCase uc)
        {
            _uc = uc;
        }

        public void OnSuccess(ZResponse<ManageMediaResponse> response)
        {
            _uc.PresenterCallback?.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc?.PresenterCallback?.OnFailure(exception);
        }
    }

    public interface IManageMediaPresenterCallback : ICallback<ManageMediaResponse>
    {

    }
}