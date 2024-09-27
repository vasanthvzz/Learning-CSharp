using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class AddMediaView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintTitle("Add New Media");
            GetMediaDetails();
        }

        private void GetMediaDetails()
        {
            Console.WriteLine("Enter the Media id");
            long mediaId = ConsoleManager.GetLong();
            Console.WriteLine("Enter the Media name ");
            string mediaName = Console.ReadLine();
            Console.WriteLine("Enter the Media description");
            string mediaDescription = Console.ReadLine();
            Console.WriteLine("Enter the movie realease date (yyyy-MM-dd)");
            DateOnly date = ConsoleManager.GetDateOnly();
            Media media = new Media(mediaId, mediaName, mediaDescription, MediaType.MOVIE, date);
            //Get tags
            ValidateTags(media);
            //Create request object

        }

        private void ValidateTags(Media media)
        {
            new ShowTagsView().Initialize();
            Console.Write("Enter the tag id to filter media: ");
            int[] tagIds = ConsoleManager.GetIntegers();
            TagValidationRequest request = new TagValidationRequest(tagIds);
            TagValidationPresenterCallback callback = new TagValidationPresenterCallback(media, this);
            TagValidationUseCase useCase = new TagValidationUseCase(request, callback);
            useCase.Execute();
        }

        private void AddMedia(AddMediaRequest request)
        {
            var callback = new AddMediaPresenterCallback();
            var useCase = new AddMediaUseCase(request, callback);
            useCase.Execute();
        }

        private class TagValidationPresenterCallback : ICallback<TagValidationResponse>
        {
            private Media MediaData;
            private AddMediaView _view;

            public TagValidationPresenterCallback(Media mediaData, AddMediaView view)
            {
                MediaData = mediaData;
                _view = view;
            }

            public void OnSuccess(ZResponse<TagValidationResponse> response)
            {
                List<int> validTags = response.Data.ValidTags;
                List<int> inValidTags = response.Data.InValidTags;
                if (inValidTags.Count == 0)
                {
                    var mediaRequest = new AddMediaRequest(MediaData, validTags.ToArray());
                    _view.AddMedia(mediaRequest);
                }
                else
                {
                    Console.WriteLine("Some of the tags are invalid !");
                    Console.WriteLine("Invalid tags: " + string.Join(", ", inValidTags));
                    _view.ValidateTags(MediaData);
                }
            }

            public void OnFailure(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }

    public class AddMediaPresenterCallback : IAddMediaPresenterCallback
    {
        public void OnSuccess(ZResponse<AddMediaResponse> response)
        {
            Console.WriteLine("Media has been added with the Media id " + response.Data.MediaId);
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine($"Failed to add Media: {exception.Message}");
        }
    }
}
