using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Domain
{
    public class ShowTagsUseCase : UseCaseBase<ShowTagsResponse>
    {
        private ShowTagsRequest _request;
        private IShowTagsDataManager _dm;
        public ShowTagsUseCase(ShowTagsRequest request, ICallback<ShowTagsResponse> callback) : base(callback)
        {
            _request = request;
            _dm = new ShowTagsDataManager();
        }

        public override void Action()
        {
            _dm.GetMediaTagList(_request, new ShowTagsUseCaseCallback(this));
        }
    }

    public class ShowTagsRequest
    {
    }

    public class ShowTagsResponse
    {
        public List<Tag> TagList { get; }

        public ShowTagsResponse(List<Tag> tagList)
        {
            TagList = tagList;
        }
    }

    public class ShowTagsUseCaseCallback : ICallback<ShowTagsResponse>
    {
        private ShowTagsUseCase _uc;

        public ShowTagsUseCaseCallback(ShowTagsUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnSuccess(ZResponse<ShowTagsResponse> response)
        {
            _uc?.PresenterCallback?.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc.PresenterCallback?.OnFailure(exception);
        }
    }
    public interface IShowTagsDataManager
    {
        public void GetMediaTagList(ShowTagsRequest request, ShowTagsUseCaseCallback callback);
    }
    public interface IShowTagsPresenterCallback : ICallback<ShowTagsRequest> { }
}
