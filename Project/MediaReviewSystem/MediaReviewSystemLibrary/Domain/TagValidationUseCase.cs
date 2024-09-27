using CommonClassLibrary;
using MediaReviewSystemLibrary.Data;

namespace MediaReviewSystemLibrary.Domain
{
    public class TagValidationUseCase : UseCaseBase<TagValidationResponse>
    {
        private TagValidationRequest _request;
        private ITagValidationDataManager _dm;

        public TagValidationUseCase(TagValidationRequest request, ICallback<TagValidationResponse> callback) : base(callback)
        {
            _request = request;
            _dm = new TagValidationDataManager();
        }

        public override void Action()
        {
            _dm.ValidateTag(_request, new TagValidationUseCaseCallback(this));
        }
    }

    public class TagValidationRequest
    {
        public int[] TagList { get; }

        public TagValidationRequest(int[] tagList)
        {
            TagList = tagList;
        }
    }

    public class TagValidationResponse
    {
        public List<int> ValidTags { get; }
        public List<int> InValidTags { get; }

        public TagValidationResponse(List<int> validTags, List<int> inValidTags)
        {
            ValidTags = validTags;
            InValidTags = inValidTags;
        }
    }

    public class TagValidationUseCaseCallback : ICallback<TagValidationResponse>
    {
        private TagValidationUseCase _uc;

        public TagValidationUseCaseCallback(TagValidationUseCase uc)
        {
            _uc = uc;
        }

        public void OnSuccess(ZResponse<TagValidationResponse> response)
        {
            _uc?.PresenterCallback?.OnSuccess(response);
        }

        public void OnFailure(Exception exception)
        {
            _uc?.PresenterCallback?.OnFailure(exception);
        }
    }

    public interface ITagValidationDataManager
    {
        public void ValidateTag(TagValidationRequest request, TagValidationUseCaseCallback callback);
    }

    public interface TagsValidationPresenterCallback : ICallback<TagValidationResponse> { }
}
