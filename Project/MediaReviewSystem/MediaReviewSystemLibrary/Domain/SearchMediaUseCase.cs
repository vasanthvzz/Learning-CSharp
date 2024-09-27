using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;

namespace MediaReviewSystemLibrary.Domain
{
    public class SearchMediaUseCase : UseCaseBase<SearchMediaResponse>
    {
        private ISearchMediaDataManager _dm;
        private SearchMediaRequest _request;

        public SearchMediaUseCase(SearchMediaRequest request, ICallback<SearchMediaResponse> callback) : base(callback)
        {
            _request = request;
            _dm = new SearchMediaDataManager();
        }

        public override void Action()
        {
            _dm.SearchMedia(_request, new SearchMediaUseCaseCallback(this));
        }
    }

    public class SearchMediaUseCaseCallback : ICallback<SearchMediaResponse>
    {
        private SearchMediaUseCase _uc;

        public SearchMediaUseCaseCallback(SearchMediaUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnSuccess(ZResponse<SearchMediaResponse> response)
        {
            _uc?.PresenterCallback.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc?.PresenterCallback.OnFailure(exception);
        }
    }

    public class SearchMediaResponse
    {
        public List<CompactMediaBObj> MediaList { get; set; }

        public SearchMediaResponse(List<CompactMediaBObj> mediaList)
        {
            MediaList = mediaList;
        }
    }

    public class SearchMediaRequest
    {
        public string[] Keywords { get; set; }

        public SearchMediaRequest(string[] keyword)
        {
            Keywords = keyword;
        }
    }

    public interface ISearchMediaDataManager
    {
        public void SearchMedia(SearchMediaRequest request, SearchMediaUseCaseCallback callback);
    }

    public interface ISearchMediaPresenterCallback : ICallback<SearchMediaResponse>
    {
    }
}
