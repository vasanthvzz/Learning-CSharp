using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class FilterMediaByTagView : IView
    {
        //Summary Get tags from user -> Validate if the tag ids present(TagValidationUseCase) -> get movies based on the tags(FilterMediaByTagUseCase)
        public void Initialize()
        {
            ConsoleManager.PrintTitle("Filter Media by Tags");
            ValidateTags();
        }

        private int[] GetTagIds()
        {
            new ShowTagsView().Initialize();
            Console.Write("Enter the tag id to filter media: ");
            int[] tagIds = ConsoleManager.GetIntegers();
            return tagIds;
        }

        public void ValidateTags()
        {
            int[] tagIds = GetTagIds();
            var request = new TagValidationRequest(tagIds);
            var callback = new TagValidationPresenterCallback(this);
            var useCase = new TagValidationUseCase(request, callback);
            useCase.Execute(); // This goes to tag validation presenter call back
        }
    }

    public class TagValidationPresenterCallback : TagsValidationPresenterCallback
    {

        private FilterMediaByTagView _view;

        public TagValidationPresenterCallback(FilterMediaByTagView view)
        {
            _view = view;
        }

        public void OnSuccess(ZResponse<TagValidationResponse> response)
        {
            List<int> validTags = response.Data.ValidTags;
            List<int> invalidTags = response.Data.InValidTags;
            if (invalidTags.Count == 0)
            {
                var request = new FilterMediaByTagRequest(validTags.ToArray());
                var callback = new FilterMediaByTagPresenterCallback();
                var useCase = new FilterMediaByTagUseCase(request, callback);
                useCase.Execute();
            }
            else
            {
                Console.WriteLine("Some of the tags are invalid !");
                Console.WriteLine("Invalid tags: " + string.Join(", ", invalidTags));
                _view.ValidateTags();
            }
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    public class FilterMediaByTagPresenterCallback : IFilterMediaByTagPresenterCallback
    {
        public void OnSuccess(ZResponse<FilterMediaByTagResponse> response)
        {
            List<CompactMediaBObj> filteredMedia = response.Data.FilteredMedia;
            foreach (var media in filteredMedia)
            {
                ConsoleManager.PrintMediaCompact(media);
            }
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }
}
