using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystemLibrary.Domain
{
    public class FilterMediaByTagUseCase : UseCaseBase<FilterMediaByTagResponse>
    {
        private IFilterMediaByTagDataManager _dm;
        private FilterMediaByTagRequest _request;

        public FilterMediaByTagUseCase(FilterMediaByTagRequest request, ICallback<FilterMediaByTagResponse> callback)
            : base(callback)
        {
            _request = request;
            _dm = new FilterMediaByTagDataManager();
        }

        public override void Action()
        {
            _dm.FilterMediaByTag(_request, new FilterMediaByTagUseCaseCallback(this));
        }
    }

    public class FilterMediaByTagUseCaseCallback : ICallback<FilterMediaByTagResponse>
    {
        private FilterMediaByTagUseCase _uc;

        public FilterMediaByTagUseCaseCallback(FilterMediaByTagUseCase useCase)
        {
            _uc = useCase;
        }

        public void OnSuccess(ZResponse<FilterMediaByTagResponse> response)
        {
            _uc?.PresenterCallback.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc?.PresenterCallback.OnFailure(exception);
        }
    }

    public class FilterMediaByTagRequest
    {
        public int[] Tags { get; set; }

        public FilterMediaByTagRequest(int[] tag)
        {
            Tags = tag;
        }
    }

    public class FilterMediaByTagResponse
    {
        public List<CompactMediaBObj> FilteredMedia { get; set; }

        public FilterMediaByTagResponse(List<CompactMediaBObj> filteredMedia)
        {
            FilteredMedia = filteredMedia;
        }
    }

    public interface IFilterMediaByTagPresenterCallback : ICallback<FilterMediaByTagResponse>
    {
    }
}
