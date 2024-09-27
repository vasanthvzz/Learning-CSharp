using CommonClassLibrary;
using MediaReviewSystemLibrary.Domain;
using MediaReviewSystemLibrary.Models.Entities;

namespace MediaReviewSystem.View
{
    public class ShowTagsView : IView
    {
        public void Initialize()
        {
            Console.WriteLine("\t----Tag List----");
            ShowTagsRequest request = new ShowTagsRequest();
            ShowTagsPresenterCallback callback = new ShowTagsPresenterCallback();
            ShowTagsUseCase usecase = new ShowTagsUseCase(request, callback) ;
            usecase.Execute();
        }

        private class ShowTagsPresenterCallback : ICallback<ShowTagsResponse>
        {

            public void OnSuccess(ZResponse<ShowTagsResponse> response)
            {
                List<Tag> tagList = response.Data.TagList;
                foreach (Tag tag in tagList)
                {
                    Console.WriteLine($"{tag.TagId}  -  {tag.TagName}");
                }
            }

            public void OnFailure(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
