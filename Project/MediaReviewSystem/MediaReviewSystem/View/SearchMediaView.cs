using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models;
using MediaReviewSystemLibrary.Utils;

namespace MediaReviewSystem.View
{
    public class SearchMediaView : IView
    {
        public void Initialize()
        {
            ConsoleManager.PrintTitle("Search Media");
            SearchForMedia();
        }

        private void SearchForMedia()
        {
            Console.Write("Enter a keyword to search: ");
            string keyword = Console.ReadLine();

            SearchMediaRequest request = new SearchMediaRequest(keyword.ToLower().Split());
            SearchMediaPresenterCallback callback = new SearchMediaPresenterCallback();
            SearchMediaUseCase useCase = new SearchMediaUseCase(request, callback);
            useCase.Execute();
        }
    }

    public class SearchMediaPresenterCallback : ISearchMediaPresenterCallback
    {
        public void OnSuccess(ZResponse<SearchMediaResponse> response)
        {
            List<CompactMediaBObj> mediaList = response.Data.MediaList;
            foreach (var media in mediaList)
            {
                ConsoleManager.PrintMediaCompact(media);
            }
        }

        public void OnFailure(Exception exception)
        {
            Console.WriteLine("Search failed: " + exception.Message);
        }
    }
}
